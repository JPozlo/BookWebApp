using System.Collections.Generic;
using Books.Data.Model;

namespace Books.Services
{
    public interface IBookService
    {
        public void AddBook(Book book);
        public List<Book> GetAllBooks();
        public Book GetBook(int bookId);
        public void DeleteBook(int bookId);
    }
}