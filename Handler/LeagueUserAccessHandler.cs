using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kyniusBETAPI.Handler;

public class LeagueUserAccessHandler : AuthorizationHandler<LeagueUserAccessRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LeagueUserAccessHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LeagueUserAccessRequirement requirement)
    {
            var routeData = _httpContextAccessor?.HttpContext?.GetRouteData();
            var leagueId = routeData?.Values["leagueId"]?.ToString();
            if (context.User.HasClaim(x => x.Type == leagueId && x.Value == UserRoles.User))
            {
                context.Succeed(requirement);
            }
            else if (context.User.HasClaim(x => x.Type == leagueId && x.Value == UserRoles.Admin))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
    }
}