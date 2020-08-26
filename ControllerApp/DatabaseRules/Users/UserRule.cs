using ControllerApp.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.Users
{
    public class UserRule : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.CellPhonenumber).IsRequired();

            builder.HasOne(p => p.UserType).WithMany().HasForeignKey(p => p.UserTypeId);
        }
    }
}
