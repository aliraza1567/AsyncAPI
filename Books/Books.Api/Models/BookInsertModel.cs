using System;

namespace Books.Api.Models
{
    public class BookInsertModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
}