using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BooksCollection
    {
        private List<Book> _booksList = new List<Book>();
        private IBookReader _bookReader = new BookBinaryReader();
        private IBookWriter _bookWriter = new BookBinaryWriter();

        public BooksCollection(){}

        public bool DownloadBooksCollection(string path)
        {
            try
            {
                using (Stream stream = File.OpenRead(path))
                {
                    List<Book> newBooksList = _bookReader.DownloadBookCollection(stream);
                    _booksList.Clear();
                    foreach (var book in newBooksList)
                    {
                        _booksList.Add(book);
                    }
                }
                return true;
            }
            catch (IOException ex )
            {
                throw new IOException("File can not be processed!", ex);
            }
        }

        public bool SaveBooksCollection(string path)
        {
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                _bookWriter.SaveBooksCollection(stream, _booksList);
            }
            return true;
        }

        public bool AddBook(string authorName, string bookName, string genre, int publishingYear, int numberOfPages)
        {
            Book currentBook = new Book(authorName, bookName, genre, publishingYear, numberOfPages);
            if (_booksList.Find(x => x.Equals(currentBook)) == null)
            {
                _booksList.Add(currentBook);
                return true;
            }
            throw new ApplicationException("This book already exist!");
        }

        public bool RemoveBook(string bookName)
        {
            Book currentBook = _booksList.Find(x => x.BookName.Equals(bookName));
            if (currentBook != null)
            {
                _booksList.Remove(currentBook);
                return true;
            }
            throw new ApplicationException("This book doesn't exist!");
        }

        public Book[] FindByBookName(string bookName)
        {
            //	FindByTag(найти книгу по заданному критерию);
            return _booksList.FindAll(x => x.BookName.Contains(bookName)).ToArray();
        }
        public Book[] FindByAuthorName(string authorName)
        {
            return _booksList.FindAll(x => x.AuthorName.Contains(authorName)).ToArray();
        }
        public Book[] FindByGenre(string genre)
        {
            return _booksList.FindAll(x => x.Genre.Contains(genre)).ToArray();
        }
        public Book[] FindByPublishingYear(int year)
        {
            return _booksList.FindAll(x => x.PublishingYear.Equals(year)).ToArray();
        }
        public Book[] FindByNumberOfPages(int number)
        {
            return _booksList.FindAll(x => x.NumberOfPages.Equals(number)).ToArray();
        }

        public bool SortByAuthorName()
        {
            _booksList.Sort(new CompareBooksByAuthorName());
            return true;
        }
        public bool SortByBookName()
        {
            //	SortBooksByTag (отсортировать список книг по заданному критерию).
            _booksList.Sort(new CompareBooksByBookName());
            return true;
        }
        public bool SortByGenre()
        {
            _booksList.Sort(new CompareBooksByGenre());
            return true;
        }
        public bool SortByPublishingYear()
        {
            _booksList.Sort(new CompareBooksByPublishingYear());
            return true;
        }
        public bool SortByNumberOfPages()
        {
            _booksList.Sort(new CompareBooksByNubberOfPages());
            return true;
        }
        public override string ToString()
        {
            string resultString = "";
            foreach (var variable in _booksList)
            {
                resultString = resultString + variable.ToString() + "\n";
            }
            return resultString;
        }
    }


    internal class CompareBooksByAuthorName : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.AuthorName.CompareTo(second.AuthorName);
        }
    }
    internal class CompareBooksByBookName : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.BookName.CompareTo(second.BookName);
        }
    }
    internal class CompareBooksByGenre : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.Genre.CompareTo(second.Genre);
        }
    }
    internal class CompareBooksByPublishingYear : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.PublishingYear.CompareTo(second.PublishingYear);
        }
    }
    internal class CompareBooksByNubberOfPages : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.NumberOfPages.CompareTo(second.NumberOfPages);
        }
    }
}
