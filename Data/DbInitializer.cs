using Group22_ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Group22_ParkingApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ParkingAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
                new Member{FirstName="Carson",LastName="Alexander",LicenseNo="abc1234",Email = "hi@hotmail.com"},
                new Member{FirstName="Suhaib",LastName="Shahaib",LicenseNo="1234567",Email = "holla@hotmail.com"}

            };

            context.Members.AddRange(members);
            context.SaveChanges();

            var parkingLots = new ParkingLot[]
            {
                new ParkingLot{Name = "South 1", AvailableSpaces = 50, TotalSpaces = 150},
                new ParkingLot{Name = "North 1", AvailableSpaces = 4, TotalSpaces = 50},
                new ParkingLot{Name = "South 2", AvailableSpaces = 400, TotalSpaces = 500}
            };

            context.ParkingLots.AddRange(parkingLots);
            context.SaveChanges();

            var reservations = new Reservation[]
            {
                new Reservation{MemberId = 1, ParkingLotId= 1},
                new Reservation{MemberId = 1, ParkingLotId = 3},
                new Reservation{MemberId = 2, ParkingLotId = 2}
            };

            context.Reservations.AddRange(reservations);
            context.SaveChanges();

            var parkingSpots = new ParkingSpot[]
           {
                new ParkingSpot{isAvailible = true, ParkingLotId= 1, MemberId =1},
                new ParkingSpot{isAvailible = true, ParkingLotId = 3, MemberId =1},
                new ParkingSpot{isAvailible = true, ParkingLotId = 2, MemberId =2}
           };

            context.ParkingSpots.AddRange(parkingSpots);
            context.SaveChanges();
        }
    }
}
