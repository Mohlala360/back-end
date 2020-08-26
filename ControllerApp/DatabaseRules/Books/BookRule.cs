using ControllerApp.Domains.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.Books
{
    public class BookRule : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.Property(p => p.Title).IsRequired();
            builder.HasOne(p => p.Author).WithMany().HasForeignKey(p => p.AuthorId);
        }
    }
}
