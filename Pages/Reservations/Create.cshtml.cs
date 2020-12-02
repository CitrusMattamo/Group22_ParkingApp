using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group22_ParkingApp.Data;
using Group22_ParkingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Group22_ParkingApp.Authorization;

namespace Group22_ParkingApp.Pages.Reservations
{
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            IdentityContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {

            var isAuthorized = User.IsInRole(Constants.ParkingStaffRole) ||
                User.IsInRole(Constants.ParkingAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            //todo - get memberId from Model
            var memberId = 3;

            if (!isAuthorized)
            {
                ViewData["MemberId"] = new SelectList(Context.Members, "Id", "Email", memberId);
            }
            else
            {
                ViewData["MemberId"] = new SelectList(Context.Members, "Id", "Email");
            }
            
            ViewData["ParkingLotId"] = new SelectList(Context.ParkingLots, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Reservations.Add(Reservation);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
