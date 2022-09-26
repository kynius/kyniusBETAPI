using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kyniusBETAPI.Handler;

public class LeagueUserAccessHandler : AuthorizationHandler<LeagueUserAccessRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LeagueUserAccessRequirement requirement)
    {
        if (context.Resource is AuthorizationFilterContext authContext)
        {
            var leagueId = authContext.RouteData.Values["leagueId"];
            var leagueUser = string.Concat(UserRoles.User, leagueId.ToString());
            if (context.User.HasClaim(claim => claim.Value == leagueUser))
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