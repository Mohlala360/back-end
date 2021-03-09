using ControllerApp.Domains.Cars;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerApp.DatabaseRules.Cars
{
    public class CarBookStatusRule : IEntityTypeConfiguration<CarBookStatus>
    {
        public void Configure(EntityTypeBuilder<CarBookStatus> builder)
        {
            builder.ToTable("CarBookStatuses");

            builder.Property(p => p.Status).IsRequired();


            List<CarBookStatuses> carBookStatusEnum =
                Enum.GetValues(typeof(CarBookStatuses)).Cast<CarBookStatuses>().ToList();

            var carBookStatuses = new List<CarBookStatus>();

            foreach (CarBookStatuses carBookStatus in carBookStatusEnum)
            {
                carBookStatuses.Add(new CarBookStatus
                {
                    CarBookStatusId = (int)carBookStatus,
                    Status = carBookStatus.Humanize(LetterCasing.Title)
                });
            }

            builder.HasData(carBookStatuses.ToArray());
        }
    }
}