using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Requirement;
using Microsoft.AspNetCore.Authorization;

namespace kyniusBETAPI.Handler;

public class LeagueAdminAccessHandler : AuthorizationHandler<LeagueAdminAccessRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LeagueAdminAccessHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException();
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LeagueAdminAccessRequirement requirement)
    {
            var routeData = _httpContextAccessor?.HttpContext?.GetRouteData();
            var leagueId = routeData?.Values["leagueId"]?.ToString();
            if (context.User.HasClaim(x => x.Type == leagueId && x.Value == UserRoles.Admin))
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