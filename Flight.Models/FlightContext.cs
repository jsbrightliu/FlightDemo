using Flight.Models.Entities;
using Flight.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Flight.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options): base(options) { }

        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AirportTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}