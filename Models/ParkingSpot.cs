using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group22_ParkingApp.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public bool isAvailible { get; set; }
        public ICollection<ParkingLot> ParkingLots { get; set; }
    }
}
