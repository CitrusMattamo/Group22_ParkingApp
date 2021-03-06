﻿using System.Threading.Tasks;
using Group22_ParkingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Group22_ParkingApp.Authorization
{
    public class ParkingStaffAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Member>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Member resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for approval/reject, return.
            if (requirement.Name != Constants.ApproveOperationName &&
                requirement.Name != Constants.RejectOperationName)
            {
                return Task.CompletedTask;
            }

            // Managers can approve or reject.
            if (context.User.IsInRole(Constants.ParkingStaffRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
