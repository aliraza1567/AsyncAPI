using Books.Domain.Common;
using System;

namespace Books.Domain.Entities
{
    public class Author: IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}