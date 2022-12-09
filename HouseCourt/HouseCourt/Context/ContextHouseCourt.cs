using System;
using System.Collections.Generic;
using System.Data.Entity;
using HouseCourt.Entities;

namespace HouseCourt.Context
{
    public class ContextHouseCourt : DbContext
    {
        public ContextHouseCourt () : base("HouseCourtDB")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ContextHouseCourt>());
            if(!Houses.Any())
            {
                House house = new House
                {
                    MACAdress = "555-12A-9DC",
                    HouseName = "Toto's house",
                    Users = null
                };
                this.Houses.Add(house);
                SaveChanges();
            }
        }

        public DbSet<Reading>? Readings { get; set; }
        public DbSet<House>? Houses { get; set; }
        public DbSet<TypeReading>? TypeReading { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Units>? Unit { get; set; }
    }
}