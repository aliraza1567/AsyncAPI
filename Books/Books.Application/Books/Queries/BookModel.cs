using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Application.Authors.Queries;

namespace Books.Application.Books.Queries
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorModel Author { get; set; }
    }
}
