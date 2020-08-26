using ControllerApp.Domains.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.Books
{
    public class AuthorRule : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.Property(p => p.AuthorName).IsRequired();
            builder.Property(p => p.AuthorSurname).IsRequired();
        }
    }
}
