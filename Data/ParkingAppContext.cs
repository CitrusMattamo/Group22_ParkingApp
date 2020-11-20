using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Models;

namespace Group22_ParkingApp.Data
{
    public class ParkingAppContext : DbContext
    {
        public ParkingAppContext (DbContextOptions<ParkingAppContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<ParkingLot>().ToTable("ParkingLot");
        }
    }
}
