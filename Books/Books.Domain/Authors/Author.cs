using System;
using Books.Domain.Common;

namespace Books.Domain.Authors
{
    public class Author: IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}