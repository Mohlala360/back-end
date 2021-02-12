using ControllerApp.Domains.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerApp.DatabaseRules.Cars
{
    public class CarRule : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.Property(p => p.RegistrationNumber).IsRequired();
        }
    }
}
