using Flight.Models.EnityConfigurations;
using Flight.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
