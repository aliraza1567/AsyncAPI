using Books.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Books.Persistance.Authors
{
    public class CustomerConfiguration : EntityTypeConfiguration<Author>
    {
        public CustomerConfiguration()
        {
            ToTable("Authors");
            HasKey(p => p.Id);
            Property(p => p.FirstName).IsRequired().HasMaxLength(150);
            Property(p => p.LastName).IsRequired().HasMaxLength(150);
        }
    }
}
