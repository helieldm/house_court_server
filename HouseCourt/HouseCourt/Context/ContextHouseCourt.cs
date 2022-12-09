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
        }

        public DbSet<Reading>? Readings { get; set; }
        public DbSet<Home>? Houses { get; set; }
        public DbSet<TypeReading>? TypeReading { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Unit>? Unit { get; set; }
    }
}