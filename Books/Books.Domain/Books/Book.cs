using System;
using Books.Domain.Authors;
using Books.Domain.Common;

namespace Books.Domain.Books
{
    public class Book: IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
