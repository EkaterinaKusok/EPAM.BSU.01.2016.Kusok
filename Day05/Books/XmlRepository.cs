using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Books
{
    public class XmlRepository : IRepository
    {
        public IEnumerable<Book> Load(string path)
        {
            List<Book> books = new List<Book>();
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.CloseInput = true;
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.IgnoreWhitespace = true;
                using (XmlReader reader = XmlReader.Create(path, settings))
                {
                    while (!reader.EOF)
                    {
                        reader.ReadStartElement("Book");
                        string a = reader.ReadElementString("AuthorName");
                        string b = reader.ReadElementString("BookTitle");
                        string c = reader.ReadElementString("Genre");
                        int d = Int32.Parse(reader.ReadElementString("PublishingYear"));
                        int e = Int32.Parse(reader.ReadElementString("NumberOfPages"));
                        books.Add(new Book(a,b,c,d,e));
                        reader.ReadEndElement();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException("File doesn't exist!", ex);
            }
            catch (XmlException ex)
            {
                throw new ApplicationException("File can't be processed!", ex);
            }
            return books;
        }

        public bool Save(string path, IEnumerable<Book> books)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.CloseOutput = true;
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                    foreach (var book in books)
                    {
                        writer.WriteStartElement("Book");
                        writer.WriteElementString("AuthorName", book.AuthorName);
                        writer.WriteElementString("BookTitle", book.BookTitle);
                        writer.WriteElementString("Genre", book.Genre);
                        writer.WriteElementString("PublishingYear", book.PublishingYear.ToString());
                        writer.WriteElementString("NumberOfPages", book.NumberOfPages.ToString());
                        writer.WriteEndElement();
                    }
                }
            }
            catch (XmlException ex)
            {
                throw new ApplicationException("File can't be save!", ex);
            }
            return true;
        }
    }
}
