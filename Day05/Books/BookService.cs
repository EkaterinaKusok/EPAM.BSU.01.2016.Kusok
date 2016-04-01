using System;
using System.Collections.Generic;
using System.IO;

namespace Books
{
    public sealed class BookServise
    {
        public List<Book> BooksList{ get; set; }

        public BookServise() { }
        public BookServise(IEnumerable<Book> collection)
        {
            foreach (var variable in collection)
                BooksList.Add(variable);
        }

        public bool Load(string path, IRepository repository)
        {
            try
            {
                this.BooksList = (List<Book>)repository.Load(path);
                return true;
            }
            catch (IOException ex)
            {
                throw new ApplicationException("Operation can't be done!", ex);
            }
        }

        public bool Save(string path, IRepository repository)
        {
            try
            {
                repository.Save(path, this.BooksList);
            }
            catch (IOException ex)
            {
                throw new ApplicationException("Operation can't be done!", ex);
            }
            return true;
        }

        public bool RemoveBookByTitle(string bookTitle)
        {
            Book currentBook = BooksList.Find(x => x.BookTitle.Equals(bookTitle));
            if (currentBook != null)
            {
                BooksList.Remove(currentBook);
                return true;
            }
            throw new ApplicationException("This book doesn't exist!");
        }
    }


    public interface IRepository
    {
        IEnumerable<Book> Load(string path);
        bool Save(string path, IEnumerable<Book> books);
    }

    public class CompareBooksByAuthorName : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.AuthorName.CompareTo(second.AuthorName);
        }
    }

    public class CompareBooksByBookTitle : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.BookTitle.CompareTo(second.BookTitle);
        }
    }

    public class CompareBooksByGenre : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.Genre.CompareTo(second.Genre);
        }
    }

    public class CompareBooksByPublishingYear : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.PublishingYear.CompareTo(second.PublishingYear);
        }
    }

    public class CompareBooksByNubberOfPages : Comparer<Book>
    {
        public override int Compare(Book first, Book second)
        {
            return first.NumberOfPages.CompareTo(second.NumberOfPages);
        }
    }
}
