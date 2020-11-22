﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group22_ParkingApp.Models
{
    public class NonMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNo { get; set; }
        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
