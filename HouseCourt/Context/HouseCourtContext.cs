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
        public DbSet<Type>? Type { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Unit>? Unit { get; set; }
        public DbSet<Sensor>? Sensors { get; set; }
        public DbSet<Consumption>? Consumptions { get; set; }
        public DbSet<Entities.Task>? Tasks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
                new Unit {Id = 1, Name = "°C" },
                new Unit {Id = 2, Name = "%" }
            );
            
            modelBuilder.Entity<Type>().HasData(
                new Type {Id = 1, Name = "Temperature", UnitId = 1},
                new Type {Id = 2, Name = "Humidity", UnitId = 2}
            );
        }
    }
}