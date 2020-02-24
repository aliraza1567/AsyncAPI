using Books.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Books.Persistance.Books
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            ToTable("Books");
            HasKey(p => p.Id);
            Property(p => p.Title).IsRequired().HasMaxLength(150);
            Property(p => p.Description).IsRequired().HasMaxLength(2500);
            HasRequired(p => p.Author);
        }
    }
}