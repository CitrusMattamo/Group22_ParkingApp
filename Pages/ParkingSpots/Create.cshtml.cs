using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;

namespace Group22_ParkingApp.Pages.ParkingSpots
{
    public class CreateModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public CreateModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email");
        ViewData["ParkingLotId"] = new SelectList(_context.ParkingLots, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ParkingSpot ParkingSpot { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ParkingSpots.Add(ParkingSpot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
