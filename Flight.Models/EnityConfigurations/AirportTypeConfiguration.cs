using Flight.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Models.EnityConfigurations
{
    internal class AirportTypeConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(300).IsRequired();

            builder.Property(p => p.Code).HasMaxLength(50).IsRequired();
        }
    }
}