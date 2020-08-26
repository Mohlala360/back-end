using ControllerApp.Domains.UserBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.UserBooks
{
    public class UserBookStateRule : IEntityTypeConfiguration<UserBookState>
    {
        public void Configure(EntityTypeBuilder<UserBookState> builder)
        {
            builder.ToTable("UserBookStates");

            builder.HasKey(p => new { p.UserBookId, p.UserBookStatusId });
            builder.HasOne(p => p.UserBook).WithMany(p => p.UserBookStates).HasForeignKey(p => p.UserBookId);
            builder.HasOne(p => p.UserBookStatus).WithMany().HasForeignKey(p => p.UserBookStatusId);
        }
    }
}
