using ControllerApp.Domains.UserBooks;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerApp.DatabaseRules.UserBooks
{
    public class UserBookStatusRule : IEntityTypeConfiguration<UserBookStatus>
    {
        public void Configure(EntityTypeBuilder<UserBookStatus> builder)
        {
            builder.ToTable("UserBookStatuses");

            builder.Property(p => p.Description).IsRequired();


            List<UserBookStatuses> userBookStatusEnum =
                Enum.GetValues(typeof(UserBookStatuses)).Cast<UserBookStatuses>().ToList();

            var userBookStatuses = new List<UserBookStatus>();

            foreach (UserBookStatuses userBookStatus in userBookStatusEnum)
            {
                userBookStatuses.Add(new UserBookStatus
                {
                    UserBookStatusId = (int)userBookStatus,
                    Description = userBookStatus.Humanize(LetterCasing.Title)
                });
            }

            builder.HasData(userBookStatuses.ToArray());
        }
    }
}
