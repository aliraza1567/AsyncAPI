using Books.Application.Interfaces;
using Books.Domain.Authors;
using Books.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

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
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "William",
                LastName = "Shakespeare"
            };

            modelBuilder.Entity<Author>().HasData(author);
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = Guid.NewGuid(), AuthorId = author.Id, Title = "Hamlet", Description = "The Tragedy of Hamlet, Prince of Denmark, often shortened to Hamlet, is a tragedy written by William Shakespeare sometime between 1599 and 1601. It is Shakespeare's longest play with 30,557 words." },
                new Book { Id = Guid.NewGuid(), AuthorId = author.Id, Title = "Macbeth", Description = "Macbeth is a tragedy by William Shakespeare; it is thought to have been first performed in 1606. It dramatises the damaging physical and psychological effects of political ambition on those who seek power for its own sake." },
                new Book { Id = Guid.NewGuid(), AuthorId = author.Id, Title = "Romeo and Juliet", Description = "Romeo and Juliet is a tragedy written by William Shakespeare early in his career about two young star-crossed lovers whose deaths ultimately reconcile their feuding families. It was among Shakespeare's most popular plays during his lifetime and along with Hamlet, is one of his most frequently performed plays." }
            );


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
