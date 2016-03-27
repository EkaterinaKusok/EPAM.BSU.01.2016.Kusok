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
            try
            {
                List<Book> books1 = new List<Book>();
                List<Book> books2 = new List<Book>();

                try
                {
                    books1 = BookServise.Load("booklist.txt");
                    logger.Info("Download books done!");
                }
                catch (ApplicationException e)
                {
                    logger.Error(e.ToString);
                }

                try
                {
                    books1.Add(new Book("Peter Jackson Junior", "Life book", "fantasy", 1960, -463));
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
                    books1.Add(new Book("Andrey M", "Color man", "thriller", 2020, 543));
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
                    BookServise.Save("booklist.txt", books1);
                    logger.Info("Save books done correct!");
                }
                catch (ApplicationException e)
                {
                    logger.Error(e.ToString);
                }

                Console.WriteLine("--------List of books---------");
                foreach (var current in books1)
                    Console.WriteLine(current.ToString());

                books1.Sort(new CompareBooksByAuthorName());
                books1.Sort(new CompareBooksByGenre());
                books1.Sort(new CompareBooksByPublishingYear());
                books1.Sort(new CompareBooksByNubberOfPages());
                books1.Sort(new CompareBooksByBookTitle());
                Console.WriteLine("--------Sort by name of books---------");
                foreach (var current in books1)
                    Console.WriteLine(current.ToString());

                books2 = books1.FindAll(x => x.BookTitle.Contains("Book"));
                books2 = books1.FindAll(x => x.Genre.Contains("fantasy"));
                books2 = books1.FindAll(x => x.PublishingYear.Equals(2016));
                books2 = books1.FindAll(x => x.NumberOfPages.Equals(300));
                books2 = books1.FindAll(x => x.AuthorName.Contains("Author"));
                Console.WriteLine("--------Find by name of author : 'Author' ---------");
                foreach (var current in books2)
                    Console.WriteLine(current.ToString());
                try
                {
                    books1.Add(new Book("Author 0", "AName 10", "roman", 1560, 115));
                    logger.Info("Book add correct!");
                }
                catch (ApplicationException e)
                {
                    logger.Error(e.ToString);
                }
            }
            catch (Exception e)
            {
                logger.Fatal(e, "Unexpected error!");
            }
        }
    }
}
