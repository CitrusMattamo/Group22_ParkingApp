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
    public class IndexModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public IndexModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }

        public IList<ParkingLot> ParkingLot { get;set; }

        public async Task OnGetAsync()
        {
            ParkingLot = await _context.ParkingLots.ToListAsync();
        }
    }
}
