using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IdentityAPI.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var dateOfBirth = context.User.FindFirst(x => x.Type == ClaimTypes.DateOfBirth);

            if (dateOfBirth == null) { return  Task.CompletedTask; }

            var date = Convert.ToDateTime(dateOfBirth.Value);

            var age = DateTime.Now.Year - date.Year;

            if(date > DateTime.Now.AddYears(-date.Year))
            {
                age--;
            }

            if(age >= requirement.Age)
            {
               context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
