using System.Security.Claims;
using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;

public class LeagueController : ApiController
{
 
    private readonly ILeagueService _leagueService;

    public LeagueController(ILeagueService leagueService)
    {
        _leagueService = leagueService;
    }
    [HttpPost] 
    [Authorize] 
    public async Task<IActionResult> AddLeague([FromBody] LeagueDTO model)
    {
        if (ModelState.IsValid)
        {
            model.UserName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
            var response = await _leagueService.AddLeagueToBase(model);
            return Ok(response);
        }
        return BadRequest(ModelState);
    }
    [HttpGet]
    [Authorize] 
    public async Task<IActionResult> GetAllLeaguesByUser()
    {
        var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        var leagues = await _leagueService.GetLeaguesByUserName(userName);
        var strings = new List<string>();
        if (leagues.Any())
        {
            return Ok(leagues);
        }
        return BadRequest(new Response
        {
            IsSucceeded = false,
            Message = "User have no leagues",
            ResponseNumber = StatusCodes.Status404NotFound
        });
    }
    [HttpGet]
    [Route("{leagueId}")]
    [Authorize(Policy = "IsLeagueAdmin")]
    public async Task<IActionResult> GetAdminPanelByLeagueId(int leagueId)
    {
        return Ok(new Response
        {
            IsSucceeded = true,
            Message = "Authorized",
            ResponseNumber = StatusCodes.Status401Unauthorized
        });
    }
    [HttpGet]
    [Route("{leagueId}")]
    [Authorize(Policy = "IsLeagueUser")]
    public async Task<IActionResult> GetUserPanelByLeagueId(int leagueId)
    {
        return Ok(new Response
        {
            IsSucceeded = true,
            Message = "Authorized",
            ResponseNumber = StatusCodes.Status200OK
        });
    }
}