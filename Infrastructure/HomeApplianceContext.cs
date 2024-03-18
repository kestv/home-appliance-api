using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class HomeApplianceContext : DbContext
    {
        public HomeApplianceContext(DbContextOptions<HomeApplianceContext> options) : base(options)
        {

        }

        public virtual DbSet<TemperatureMeasurement> TemperatureMeasurements { get; set; } = default!;
    }
}
