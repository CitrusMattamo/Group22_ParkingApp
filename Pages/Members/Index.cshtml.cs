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

namespace Group22_ParkingApp.Pages.Members
{
    public class IndexModel : DI_BasePageModel
    {
        //private readonly ParkingAppContext _context;

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

        public IList<Member> Members { get;set; }

        //public PaginatedList<Member> Members { get; set; }



        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //CurrentSort = sortOrder;
            // using System;
            //NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //if (searchString != null)
            //{
            //    pageIndex = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}
            //CurrentFilter = searchString;

            //IQueryable<Member> membersIQ = from m in _context.Members
            //                                 select m;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    membersIQ = membersIQ.Where(m => m.LastName.Contains(searchString)
            //                           || m.FirstName.Contains(searchString));
            //}
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        membersIQ = membersIQ.OrderByDescending(s => s.LastName);
            //        break;

            //    default:
            //        membersIQ = membersIQ.OrderBy(m => m.LastName);
            //        break;
            //}

            //int pageSize = 3;
            //Members = await PaginatedList<Member>.CreateAsync(
            //    membersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            var members = from m in Context.Members
                          select m;

            var isAuthorized = User.IsInRole(Constants.ParkingStaffRole) ||
                User.IsInRole(Constants.ParkingAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized)
            {
                members = members.Where(m => m.Status == MemberStatus.Approved
                    || m.StaffId == currentUserId);
            }

            Members = await members
                .ToListAsync();
        }
    }

}
