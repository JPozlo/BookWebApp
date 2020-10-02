using System;
using System.Collections.Generic;
using System.Linq;
using Books.Data;
using Books.Data.Model;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly BooksDBContext _db;
        public BookService(BooksDBContext db)
        {
            _db = db;
        }

        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _db.Books.Find(bookId);
            if (book != null)
            {
                _db.Remove(book);
            }

            throw new InvalidOperationException("Can't delete book that doesn't exist");
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            var book = _db.Books.First(book => book.Id == bookId);
            return book;
        }
    }
}
