﻿using Group22_ParkingApp.Models;
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
                new Member{FirstName="Suhain=b",LastName="Shahaib",LicenseNo="1234567",Email = "holla@hotmail.com"}

            };

            context.Members.AddRange(members);
            context.SaveChanges();

           
        }
    }
}