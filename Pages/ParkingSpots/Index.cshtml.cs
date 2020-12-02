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

namespace Group22_ParkingApp.Pages.ParkingSpots
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

        public IList<ParkingSpot> ParkingSpots { get;set; }

        public async Task OnGetAsync()
        {

            var isAuthorized = User.IsInRole(Constants.ParkingStaffRole) ||
                User.IsInRole(Constants.ParkingAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            IQueryable<ParkingSpot> parkingSpots = from p in Context.ParkingSpots
                                              select p;

            if (!isAuthorized)
            {
                parkingSpots = parkingSpots.Where(p => p.MemberId == 3);
            }

            ParkingSpots = await parkingSpots
                .Include(p => p.Member)
                .Include(p => p.ParkingLot)
                .ToListAsync();
        }
    }
}
