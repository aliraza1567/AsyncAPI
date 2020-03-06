using Books.Application.Authors.Queries;
using System;

namespace Books.Application.Books.Queries.BookDetail
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
