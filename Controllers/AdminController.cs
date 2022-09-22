using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;

[Authorize(Roles = UserRoles.Owner)]
public class AdminController : ApiController
{
    private readonly RequestRepo _requestRepo;

    public AdminController(RequestRepo requestRepo)
    {
        _requestRepo = requestRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetMatches()
    {
        return Ok(await _requestRepo.Request("fixtures?date=2022-09-22"));
    }
}