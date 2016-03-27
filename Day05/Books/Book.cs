using System;

namespace Books
{
    public class Book : IEquatable<Book>
    {
        private string _authorName;
        private string _bookTitle;
        private string _genre;
        private int _publishingYear;
        private int _numberOfPages;

        public string AuthorName
        {
            get { return _authorName; }
        }

        public string BookTitle
        {
            get { return _bookTitle; }
        }

        public string Genre
        {
            get { return _genre; }
        }

        public int PublishingYear
        {
            get { return _publishingYear; }
        }

        public int NumberOfPages
        {
            get { return _numberOfPages; }
        }

        public Book()
        {
            _authorName = "";
            _bookTitle = "";
            _genre = "";
            _publishingYear = DateTime.Now.Year;
            _numberOfPages = 0;
        }

        public Book(string authorName, string bookTitle, string genre, int publishingYear, int numberOfPages)
        {
            if (publishingYear > DateTime.Now.Year) throw new ArgumentException("Year won't be in furure!");
            if (numberOfPages < 0) throw new ArgumentException("Book couldn'h have less 0 pages");
            _authorName = authorName;
            _bookTitle = bookTitle;
            _genre = genre;
            _publishingYear = publishingYear;
            _numberOfPages = numberOfPages;
        }

        public Book(string[] data)
        {
            if (data.Length > 4)
            {
                _authorName = data[0];
                _bookTitle = data[1];
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
            if ((System.Object) b == null)
                return false;
            return this.Equals(b);
        }

        public bool Equals(Book b)
        {
            if ((object) b == null)
                return false;
            // Return true if the fields match:
            return ((_authorName.Equals(b._authorName)) && (_bookTitle.Equals(b._bookTitle)) && _genre.Equals(b._genre)
                    && (_numberOfPages.Equals(b._numberOfPages)) && (_publishingYear.Equals(b._publishingYear)));
        }

        public override int GetHashCode()
        {
            return _authorName.GetHashCode() ^ _bookTitle.GetHashCode() ^ _genre.GetHashCode() ^ _numberOfPages ^
                   _publishingYear;
        }

        public override string ToString()
        {
            return _authorName + " -  \"" + _bookTitle + "\"  - " + _genre + " - " + _publishingYear.ToString() + " - " +
                   _numberOfPages.ToString();
        }
    }
}
