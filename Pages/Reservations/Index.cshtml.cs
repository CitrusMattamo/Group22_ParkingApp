using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Group22_ParkingApp.Authorization;

namespace Group22_ParkingApp.Pages.Reservations
{
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            IdentityContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            var isAuthorized = User.IsInRole(Constants.ParkingStaffRole) ||
                User.IsInRole(Constants.ParkingAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);
            
            
           // IList<Reservation> reservations = from r in Context.Reservations
            //                                  select r;
            /*
            if (!isAuthorized)
            {
                reservations = reservations.Where(r => r.MemberId == currentUserId )
            }
            */
            Reservation = await Context.Reservations
                .Include(r => r.Member)
                .Include(r => r.ParkingLot).ToListAsync();
        }
    }
}
