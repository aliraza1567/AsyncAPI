using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Persistance.Authors
{
    public class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);
            builder.Property(author => author.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(150);
        }
    }
}
