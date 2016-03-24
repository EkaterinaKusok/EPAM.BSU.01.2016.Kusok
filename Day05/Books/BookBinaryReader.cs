using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BookBinaryReader : IBookReader
    {
        public List<Book> DownloadBookCollection(Stream stream)
        {
            List<Book> books = new List<Book>();
            using (BinaryReader binaryReader = new BinaryReader(stream))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    books.Add(new Book(binaryReader.ReadString(), binaryReader.ReadString(), binaryReader.ReadString(),
                        binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                }
                binaryReader.Close();
            }
            return books;
        }
    }

    interface IBookReader
    {
        List<Book> DownloadBookCollection(Stream stream);
    }
}
