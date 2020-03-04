using Books.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Persistance.Books
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Title).IsRequired().HasMaxLength(150);
            builder.Property(book => book.Description).IsRequired().HasMaxLength(2500);
            builder.Property(book => book.Author).IsRequired();
        }
    }
}