using ControllerApp.Domains.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.Cars
{
    public class CarBookingRule : IEntityTypeConfiguration<CarBooking>
    {
        public void Configure(EntityTypeBuilder<CarBooking> builder)
        {
            builder.ToTable("CarBookings");

            builder.Property(p => p.ReferenceNo).HasDefaultValue("CB");
            builder.Property(p => p.BookingReason).IsRequired();

            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Car).WithMany().HasForeignKey(p => p.CarId);
        }
    }
}
