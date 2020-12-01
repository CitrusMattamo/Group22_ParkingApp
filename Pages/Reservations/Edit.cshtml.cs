using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;

namespace Group22_ParkingApp.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public EditModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservations
                .Include(r => r.Member)
                .Include(r => r.ParkingLot).FirstOrDefaultAsync(m => m.Id == id);

            if (Reservation == null)
            {
                return NotFound();
            }
           ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email");
           ViewData["ParkingLotId"] = new SelectList(_context.ParkingLots, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
