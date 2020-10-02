using System;

namespace Books.Data.Model
{
    public class Book
    {
            public int Id {get; set;}
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
    }
}