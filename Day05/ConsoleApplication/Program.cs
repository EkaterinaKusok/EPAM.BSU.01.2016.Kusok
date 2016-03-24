using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksCollection books1 = new BooksCollection();
            try
            {
                books1.DownloadBooksCollection("booklist.txt");
                Console.WriteLine("Download done!");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //books1.AddBook("Author 1", "Name 3", "fantasy", 1960, 463);
            //books1.AddBook("BAuthor 2", "Name 5", "detective", 1990, 93);
            //books1.AddBook("Author 0", "AName 10", "roman", 1560, 115);
            //books1.AddBook("CAuth1", "Name 7", "thriller", 2004, 543);
            //books1.AddBook("Auth9", "CName 5", "detective", 1849, 403);
            //books1.SaveBooksCollection("booklist.txt");
            Console.WriteLine(books1.ToString());
            Console.WriteLine("-----------------");
            books1.SortByBookName();
            Console.WriteLine(books1.ToString());
            Book[] findBooks = books1.FindByAuthorName("Author");
            foreach (var current in findBooks)
            {
                Console.WriteLine(current.ToString());
            }
        }
    }
}
