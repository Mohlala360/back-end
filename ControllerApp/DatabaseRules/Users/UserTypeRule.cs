using ControllerApp.Domains.Users;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerApp.DatabaseRules.Users
{
    public class UserTypeRule : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserTypes");

            builder.Property(p => p.Name).IsRequired();

            List<UserTypes> userTypeEmun =
                Enum.GetValues(typeof(UserTypes)).Cast<UserTypes>().ToList();

            var userTypes = new List<UserType>();

            foreach (UserTypes userType in userTypeEmun)
            {
                userTypes.Add(new UserType
                {
                    UserTypeId = (int)userType,
                    Name = userType.Humanize(LetterCasing.Title)
                });
            }

            builder.HasData(userTypes.ToArray());
        }
    }
}
