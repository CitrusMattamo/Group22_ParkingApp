﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group22_ParkingApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ParkingLotId { get; set; }
        public int MemberId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ParkingLot ParkingLot { get; set; }
        public Member Member { get; set; }
    }
}
