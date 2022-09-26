using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kyniusBETAPI.Handler;

public class LeagueAdminAccessHandler : AuthorizationHandler<LeagueAdminAccessRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LeagueAdminAccessRequirement requirement)
    {
        if (context.Resource is AuthorizationFilterContext authContext)
        {
            var leagueId = authContext.RouteData.Values["leagueId"];
            var leagueAdmin = string.Concat(UserRoles.Admin, leagueId.ToString());
            if (context.User.HasClaim(claim => claim.Value == leagueAdmin))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
        return Task.CompletedTask;
    }
}