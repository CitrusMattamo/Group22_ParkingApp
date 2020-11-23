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
    public class IndexModel : PageModel
    {
        private readonly Group22_ParkingApp.Data.ParkingAppContext _context;

        public IndexModel(Group22_ParkingApp.Data.ParkingAppContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Member> Member { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            Member = await _context.Members.ToListAsync();
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Member> membersIQ = from m in _context.Members
                                             select m;

            switch (sortOrder)
            {
                case "name_desc":
                    membersIQ = membersIQ.OrderByDescending(s => s.LastName);
                    break;
              
                default:
                    membersIQ = membersIQ.OrderBy(m => m.LastName);
                    break;
            }

            Member = await membersIQ.AsNoTracking().ToListAsync();
        }
    }

}
