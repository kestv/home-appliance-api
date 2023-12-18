using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class HomeApplianceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=home_appliance;Trusted_Connection=True;");
        }

        public virtual DbSet<TemperatureMeasurement> TemperatureMeasurements { get; set; }
    }
}
