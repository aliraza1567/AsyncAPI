using Books.Domain.Authors;
using Books.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Interfaces
{
    public interface IBooksContext: IDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}
