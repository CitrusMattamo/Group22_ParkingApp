using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group22_ParkingApp.Models
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSpaces { get; set; }
        public int AvailableSpaces { get; set; }
        public int MembershipFee { get; set; }
        public int ReservationFee { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<ParkingSpot> ParkingSpots { get; set; }
    }
}
