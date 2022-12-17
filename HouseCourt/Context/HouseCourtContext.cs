using HouseCourt.Entities;
using Microsoft.EntityFrameworkCore;
using Type = HouseCourt.Entities.Type;

namespace HouseCourt.Context
{
    public class HouseCourtContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=HouseCourt;Username=postgres;Password=root");

        public DbSet<Reading>? Readings { get; set; }
        public DbSet<House>? Houses { get; set; }
        public DbSet<Type>? TypeReading { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Unit>? Unit { get; set; }
        public DbSet<Sensor>? Sensors { get; set; }
        public DbSet<Consumption>? Consumptions { get; set; }
    }
}