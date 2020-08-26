using ControllerApp.Domains.UserBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.UserBooks
{
    public class UserBookRule : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.ToTable("UserBooks");

            builder.HasOne(p => p.Book).WithMany().HasForeignKey(p => p.BookId);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
            
        }
    }
}
