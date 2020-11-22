using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;

namespace Group22_ParkingApp.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public DetailsModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Member = await _context.Members
                .Include(m => m.Reservations)
                .ThenInclude (r => r.ParkingLot)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
                

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
