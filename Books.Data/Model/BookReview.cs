using System;

namespace Books.Data.Model
{
    public class BookReview
    {
        public int Id { get; set; }
        public string ReviewContent { get; set; }
        public string ReviewAuthor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Book Book {get; set;}
    }
}