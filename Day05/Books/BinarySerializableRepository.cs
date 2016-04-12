using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BinarySerializableRepository : IRepository
    {
        public IEnumerable<Book> Load(string path)
        {
            List<Book> books = new List<Book>();
            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream stream = File.OpenRead(path))
                {
                    while (stream.Position != stream.Length)
                    {
                        books.Add((Book) formatter.Deserialize(stream));
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException("File doesn't exist!", ex);
            }
            catch (IOException ex)
            {
                throw new ApplicationException("File can't be load!", ex);
            }
            return books;
        }

        public bool Save(string path, IEnumerable<Book> books)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
                {
                    foreach (var book in books)
                        formatter.Serialize(stream, book);
                }
            }
            catch (IOException ex)
            {
                throw new ApplicationException("File can't be save!", ex);
            }
            return true;
        }
    }
}
