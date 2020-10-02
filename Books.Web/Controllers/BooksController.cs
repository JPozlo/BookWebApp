using System;
using Books.Data.Model;
using Books.Services;
using Books.Web.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Books.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("/api/books")]
        public ActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("api/books/{id}")]
        public ActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }

        [HttpPost("api/books")]
        public ActionResult CreateBook([FromBody] NewBookRequest bookRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state isn't valid.");
            }

            var now = DateTime.UtcNow;
            var book = new Book { Title = bookRequest.Title, Author = bookRequest.Author, CreatedAt = now, UpdatedAt = now };
            _bookService.AddBook(book);
            return Ok($"Book Created: {book.Title}");
        }

        [HttpDelete("api/books/{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok($"Book deleted with ID: {id}");
        }

    }
}
