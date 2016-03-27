using System;
using System.Collections.Generic;
using System.IO;

namespace Books
{
    public sealed class BookServise
    {
        private static IRepository _repository = new BinaryRepository();

        public static List<Book> Load(string path)
        {
            try
            {
                List<Book> newBooksList = _repository.Load(path);
                return newBooksList;
            }
            catch (IOException ex)
            {
                throw new ApplicationException("Operation can't be done!", ex);
            }
        }

        public static bool Save(string path, List<Book> bookList)
        {
            try
            {
                _repository.Save(path, bookList);
            }
            catch (IOException ex)
            {
                throw new ApplicationException("Operation can't be done!", ex);
            }
            return true;
        }

        public static List<Book> RemoveBookByTitle(string bookTitle, List<Book> booksList)
        {
            Book currentBook = booksList.Find(x => x.BookTitle.Equals(bookTitle));
            if (currentBook != null)
            {
                booksList.Remove(currentBook);
                return booksList;
            }
            throw new ApplicationException("This book doesn't exist!");
        }
    }


    interface IRepository
    {
        List<Book> Load(string path);
        bool Save(string path, List<Book> books);
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
