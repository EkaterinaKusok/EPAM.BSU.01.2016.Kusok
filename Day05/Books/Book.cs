using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book : IEquatable<Book>
    {
        private string _authorName;
        private string _bookName;
        private string _genre;
        private int _publishingYear;
        private int _numberOfPages;
        internal string AuthorName { get { return _authorName; } }
        internal string BookName { get { return _bookName; } }
        internal string Genre { get { return _genre; } }
        internal int PublishingYear { get { return _publishingYear; } }
        internal int NumberOfPages { get { return _numberOfPages; } }
        internal Book()
        {
            _authorName = "";
            _bookName = "";
            _genre = "";
            _publishingYear = DateTime.Now.Year;
            _numberOfPages = 0;
        }

        internal Book(string authorName, string bookName, string genre, int publishingYear, int numberOfPages)
        {
            if (publishingYear > DateTime.Now.Year) throw new ArgumentException("Year won't be in furure!");
            if (numberOfPages < 0) throw new ArgumentException("Book couldn'h have less 0 pages");
            _authorName = authorName;
            _bookName = bookName;
            _genre = genre;
            _publishingYear = publishingYear;
            _numberOfPages = numberOfPages;
        }

        internal Book(string[] data)
        {
            if (data.Length > 4)
            {
                _authorName = data[0];
                _bookName = data[1];
                _genre = data[2];
                Int32.TryParse((data[3].Trim()), out _publishingYear);
                    //throw new ArgumentException("Wrong input data (String parse to int). "); ;
                Int32.TryParse((data[4].Trim()), out _numberOfPages);
            }
            else
                throw new ArgumentException("Wrong number of patameters.");
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;
            Book b = obj as Book;
            if ((System.Object)b == null)
                return false;
            return this.Equals(b);
        }

        public bool Equals(Book b)
        {
            if ((object)b == null)
                return false;
            // Return true if the fields match:
            return ((_authorName.Equals(b._authorName)) && (_bookName.Equals(b._bookName)) && _genre.Equals(b._genre)
                    && (_numberOfPages.Equals(b._numberOfPages)) && (_publishingYear.Equals(b._publishingYear)));
        }

        public override int GetHashCode()
        {
            return _authorName.GetHashCode()^_bookName.GetHashCode()^_genre.GetHashCode()^_numberOfPages ^ _publishingYear;
        }

        public override string ToString()
        {
            return _authorName+" -  \""+_bookName+"\"  - "+_genre+" - "+_publishingYear.ToString()+" - "+_numberOfPages.ToString();
        }
    }
}
