using Group22_ParkingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Group22_ParkingApp.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
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
