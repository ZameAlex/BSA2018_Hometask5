using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BSA2018_Hometask4.DAL.DbContext
{
    public class AirportContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public AirportContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.\SQLEXPRESS; Database = AirportDB; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //entities
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Departure> Depatures { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewadress> Stewadresses { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> Types { get; set; }
    }
}
