﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;

namespace Group22_ParkingApp.Pages.ParkingSpots
{
    public class IndexModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public IndexModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }

        public IList<ParkingSpot> ParkingSpot { get;set; }

        public async Task OnGetAsync()
        {
            ParkingSpot = await _context.ParkingSpots
                .Include(p => p.Member)
                .Include(p => p.ParkingLot).ToListAsync();
        }
    }
}