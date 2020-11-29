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

namespace Group22_ParkingApp.Pages.Members
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
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyMember = new Member();

            if (await TryUpdateModelAsync<Member>(
                emptyMember,
                "member",   // Prefix for form value.
                m => m.FirstName, m => m.LastName, m => m.Email, m => m.LicenseNo))
            {
                Context.Members.Add(emptyMember);
                await Context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
