using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BookBinaryWriter : IBookWriter
    {
        public bool SaveBooksCollection(Stream stream, List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                foreach (var book in books)
                {
                    writer.Write(book.AuthorName);
                    writer.Write(book.BookName);
                    writer.Write(book.Genre);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.NumberOfPages);
                }
            }
            return true;
        }
    }

    interface IBookWriter
    {
        bool SaveBooksCollection(Stream stream, List<Book> books);
    }
}
