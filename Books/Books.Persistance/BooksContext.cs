using Books.Application.Interfaces;
using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Books.Persistance
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
