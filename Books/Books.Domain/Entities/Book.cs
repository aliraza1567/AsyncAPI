using Books.Domain.Common;
using System;

namespace Books.Domain.Entities
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
