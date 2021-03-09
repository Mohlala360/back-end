using ControllerApp.Domains.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.Cars
{
    public class CarBookStateRule : IEntityTypeConfiguration<CarBookState>
    {
        public void Configure(EntityTypeBuilder<CarBookState> builder)
        {
            builder.ToTable("CarBookStates");

            builder.HasKey(p => new { p.CarBookingId, p.CarBookStatusId });
            builder.HasOne(p => p.CarBooking).WithMany(p => p.CarBookStates).HasForeignKey(p => p.CarBookStateId);
            builder.HasOne(p => p.CarBookStatus).WithMany().HasForeignKey(p => p.CarBookStatusId);
        }
    }
}
