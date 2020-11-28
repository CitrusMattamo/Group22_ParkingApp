using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Group22_ParkingApp.Data
{
    public class ParkingAppContext : DbContext
    {
        public ParkingAppContext (DbContextOptions<ParkingAppContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<NonMember> NonMembers { get; set; }

    }
}
