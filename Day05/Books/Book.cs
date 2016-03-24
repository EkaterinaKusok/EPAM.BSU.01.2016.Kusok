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
            _authorName = authorName;
            _bookName = bookName;
            _genre = genre;
            _publishingYear = publishingYear;
            _numberOfPages = numberOfPages;
        }
        internal Book(string [] data)
        {
            if (data.Length > 4)
            {
                _authorName = data[0];
                _bookName = data[1];
                _genre = data[2];
                try
                {
                    _publishingYear = Int32.Parse(data[3].Trim());
                    _numberOfPages = Int32.Parse(data[4].Trim());
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Wrong input data", ex);
                }
            }
            else 
                throw new ArgumentException("Wrong number of patameters.");
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
                return false;
            // If parameter cannot be cast to Book return false.
            Book b = obj as Book;
            if ((System.Object)b == null)
                return false;
            // Return true if the fields match:
            return ((_authorName.Equals(b._authorName)) && (_bookName.Equals(b._bookName)) && _genre.Equals(b._genre)
                && (_numberOfPages.Equals(b._numberOfPages)) && (_publishingYear.Equals(b._publishingYear)));
        }

        public bool Equals(Book b)
        {
            // If parameter is null return false:
            if ((object)b == null)
                return false;
            // Return true if the fields match:
            return ((_authorName.Equals(b._authorName)) && (_bookName.Equals(b._bookName)) &&
                    _genre.Equals(b._genre)
                    && (_numberOfPages.Equals(b._numberOfPages)) && (_publishingYear.Equals(b._publishingYear)));
        }

        public override int GetHashCode()
        {
            return _numberOfPages ^ _publishingYear;
        }

        public override string ToString()
        {
            return _authorName+" -  \""+_bookName+"\"  - "+_genre+" - "+_publishingYear.ToString()+" - "+_numberOfPages.ToString();
        }
    }
}
