using System.Reflection;
using Books.Application.Interfaces;
using Books.Domain.Authors;
using Books.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence
{
    public class BooksContext: DbContext, IBooksContext
    {
        public BooksContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
