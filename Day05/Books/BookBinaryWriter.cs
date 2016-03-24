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
            using (BinaryWriter binaryWriter = new BinaryWriter(stream))
            {
                foreach (var book in books)
                {
                    binaryWriter.Write(book.AuthorName);
                    binaryWriter.Write(book.BookName);
                    binaryWriter.Write(book.Genre);
                    binaryWriter.Write(book.PublishingYear);
                    binaryWriter.Write(book.NumberOfPages);
                }
                binaryWriter.Close();
            }
            return true;
        }
    }

    interface IBookWriter
    {
        bool SaveBooksCollection(Stream stream, List<Book> books);
    }
}
