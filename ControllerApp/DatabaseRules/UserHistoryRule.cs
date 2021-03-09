using ControllerApp.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules
{
    public class UserHistoryRule : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.ToTable("UserHistories");

            builder.Property(p => p.Action).IsRequired();            
        }
    }
}
