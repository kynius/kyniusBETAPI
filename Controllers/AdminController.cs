using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;

[Authorize(Roles = UserRoles.Owner)]
public class AdminController : ApiController
{
    private readonly AdminBuilder _builder;

    public AdminController(AdminBuilder builder)
    {
        _builder = builder;
    }

    [HttpGet]
    public async Task<IActionResult> SetMatches()
    {
        return Ok(await _builder.Build());
    }
}