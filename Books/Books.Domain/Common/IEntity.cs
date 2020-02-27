using System;

namespace Books.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
