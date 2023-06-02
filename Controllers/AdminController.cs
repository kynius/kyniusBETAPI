using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;
public class AdminController : ApiController
{
    private readonly AdminBuilder _builder;

    public AdminController(AdminBuilder builder)
    {
        _builder = builder;
    }
    [Authorize(Roles = UserRoles.Owner)]
    [HttpGet]
    public async Task<IActionResult> SetMatches()
    {
        return Ok(await _builder.Build());
    }
    [Authorize(Roles = UserRoles.Owner)]
    [HttpGet]
    public async Task<IActionResult> CheckBets()
    {
        return Ok(await _builder.CheckBets());
    }
}