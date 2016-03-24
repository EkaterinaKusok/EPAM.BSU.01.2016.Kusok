using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                BooksCollection books1 = new BooksCollection();
                try
                {
                    books1.DownloadBooksCollection("booklist.txt");
                    logger.Info("Download books done!");
                }
                catch (IOException e)
                {
                    logger.Error(e.ToString);
                }

                try
                {
                    books1.AddBook("Peter Jackson Junior", "Life book", "fantasy", 1960, -463);
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
                    books1.AddBook("Andrey M", "Color man", "thriller", 2020, 543);
                    logger.Info("Add 2nd book correct.");
                }
                catch (ArgumentException e)
                {
                    logger.Error(e.ToString);
                    //books1.AddBook("Andrey M", "Color man", "thriller", DateTime.Now.Year, 543);
                    //logger.Debug("Add new Book with correct parameters.");
                }
                //books1.AddBook("Barry Ar", "Cook book", "helper", 1990, 93);
                //books1.AddBook("Ivan Srt", "Just do it", "roman", 0, 115);
                //books1.AddBook("Marti", "#10", "detective", 2000, 403);
                try
                {
                    books1.SaveBooksCollection("booklist.txt");
                    logger.Info("Save books done correct!");
                }
                catch (IOException e)
                {
                    logger.Error(e.ToString);
                }

                Console.WriteLine("--------List of books---------");
                Console.WriteLine(books1.ToString());
                Console.WriteLine("--------Sort by name of books---------");
                books1.SortByBookName();
                Console.WriteLine(books1.ToString());
                Console.WriteLine("--------Find by name of author : 'Author' ---------");
                Book[] findBooks = books1.FindByAuthorName("Author");
                foreach (var current in findBooks)
                    Console.WriteLine(current.ToString());
                try
                {
                    books1.AddBook("Author 0", "AName 10", "roman", 1560, 115);
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
