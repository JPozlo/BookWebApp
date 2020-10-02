using Microsoft.EntityFrameworkCore;
using Books.Data.Model;

namespace Books.Data
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext()
        {

        }

        public BooksDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookReview> BookReviews { get; set; }
    }
}