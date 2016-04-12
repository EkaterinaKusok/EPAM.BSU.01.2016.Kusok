using System;
using System.Collections.Generic;
using System.IO;

namespace Books
{
    public class BinaryRepository : IRepository
    {
        public IEnumerable<Book> Load(string path)
        {
            List<Book> books = new List<Book>();
            try
            {
                using (Stream stream = File.OpenRead(path))
                {
                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        while (binaryReader.PeekChar() != -1)
                        {
                            books.Add(new Book(binaryReader.ReadString(), binaryReader.ReadString(),
                                binaryReader.ReadString(),
                                binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                        }
                        binaryReader.Close();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException("File doesn't exist!", ex);
            }
            catch (IOException ex)
            {
                throw new ApplicationException("File can't be processed!", ex);
            }
            return books;
        }

        public bool Save(string path, IEnumerable<Book> books)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                    {
                        foreach (var book in books)
                        {
                            binaryWriter.Write(book.AuthorName);
                            binaryWriter.Write(book.BookTitle);
                            binaryWriter.Write(book.Genre);
                            binaryWriter.Write(book.PublishingYear);
                            binaryWriter.Write(book.NumberOfPages);
                        }
                        binaryWriter.Close();
                    }
                }
            }
            catch (IOException ex)
            {
                throw new ApplicationException("File can't be processed!", ex);
            }
            return true;
        }
    }
}
