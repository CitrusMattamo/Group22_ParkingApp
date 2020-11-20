using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;

namespace Group22_ParkingApp.Pages.ParkingLots
{
    public class DetailsModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public DetailsModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }

        public ParkingLot ParkingLot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingLot = await _context.ParkingLots.FirstOrDefaultAsync(m => m.Id == id);

            if (ParkingLot == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
