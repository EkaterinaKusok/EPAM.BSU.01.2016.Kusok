using System;
using System.Collections.Generic;
using Books;
using NLog;

namespace ConsoleApplication
{
    class Program
    {
        //Logger logger = LogManager.GetLogger("MyClassName");
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            IRepository repository = new BinaryRepository();
            try
            {
                BookServise servise = new BookServise();
                List<Book> books2 = new List<Book>();

                try
                {
                    servise.Load("booklist.bin", repository);
                    logger.Info("Download books done!");
                }
                catch (ApplicationException e)
                {
                    logger.Error(e.ToString);
                }

                try
                {
                    servise.BooksList.Add(new Book("Peter Jackson Junior", "Life book", "fantasy", 1960, -463));
                    logger.Info("Add 1st book correct.");
                }
                catch (ArgumentException e)
                {
                    logger.Error(e.ToString);
                    //books1.AddBook("Andrey M", "Color man", "thriller", DateTime.Now.Year, 463);
                    //logger.Debug("Add new Book with correct parameters.");
                }
                try
                {
                    servise.BooksList.Add(new Book("Andrey M", "Color man", "thriller", 2020, 543));
                    logger.Info("Add 2nd book correct.");
                }
                catch (ArgumentException e)
                {
                    logger.Error(e.ToString);
                    //books1.AddBook("Andrey M", "Color man", "thriller", DateTime.Now.Year, 543);
                    //logger.Debug("Add new Book with correct parameters.");
                }
                try
                {
                    servise.Save("booklist.bin", repository);
                    logger.Info("Save books done correct!");
                }
                catch (ApplicationException e)
                {
                    logger.Error(e.ToString);
                }

                Console.WriteLine("--------List of books---------");
                foreach (var current in servise.BooksList)
                    Console.WriteLine(current.ToString());

                servise.BooksList.Sort(new CompareBooksByAuthorName());
                servise.BooksList.Sort(new CompareBooksByGenre());
                servise.BooksList.Sort(new CompareBooksByPublishingYear());
                servise.BooksList.Sort(new CompareBooksByNubberOfPages());
                servise.BooksList.Sort();
                Console.WriteLine("--------Sort by name of books---------");
                foreach (var current in servise.BooksList)
                    Console.WriteLine(current.ToString());

                books2 = servise.BooksList.FindAll(x => x.BookTitle.Contains("Book"));
                books2 = servise.BooksList.FindAll(x => x.Genre.Contains("fantasy"));
                books2 = servise.BooksList.FindAll(x => x.PublishingYear.Equals(2016));
                books2 = servise.BooksList.FindAll(x => x.NumberOfPages.Equals(300));
                books2 = servise.BooksList.FindAll(x => x.AuthorName.Contains("Author"));
                Console.WriteLine("--------Find by name of author : 'Author' ---------");
                foreach (var current in books2)
                    Console.WriteLine(current.ToString());
                try
                {
                    servise.BooksList.Add(new Book("Author 0", "AName 10", "roman", 1560, 115));
                    logger.Info("Book add correct!");

                    IRepository serRepository = new BinarySerializableRepository();
                    servise.Save("serialize.bin", serRepository);
                    servise.Load("serialize.bin", serRepository);
                    Console.WriteLine("--------Deserialization---------");
                    foreach (var current in servise.BooksList)
                        Console.WriteLine(current.ToString());
                    IRepository xmlRepository = new XmlRepository();
                    servise.Save("xmlBooks.xml", xmlRepository);
                    servise.Load("xmlBooks.xml", xmlRepository);
                    Console.WriteLine("--------From Xml---------");
                    foreach (var current in servise.BooksList)
                        Console.WriteLine(current.ToString());
                }
                catch (ApplicationException e)
                {
                    //Console.WriteLine(e.Message);
                    logger.Error(e.ToString);
                }
            }
            catch (Exception e)
            {
                logger.Fatal("Unexpected error!", e.ToString());
            }
        }
    }
}
