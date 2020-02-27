using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Books.Application.Interfaces
{
    public interface IBooksContext: IDisposable, IAsyncDisposable
    {
        DbSet<Author> Authors { get; set; }

        DbSet<Book> Books { get; set; }

        EntityEntry Add(object entity);
    }
}
