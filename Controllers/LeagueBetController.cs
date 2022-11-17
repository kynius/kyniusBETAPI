using System.Security.Claims;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;

public class LeagueBetController : ApiController
{
    private readonly IAuthorizationService _authorizationService;

    private readonly IMatchService _matchService;

    private readonly IBetService _betService;
    // GET
    public LeagueBetController(IAuthorizationService authorizationService, IMatchService matchService, IBetService betService)
    {
        _authorizationService = authorizationService;
        _matchService = matchService;
        _betService = betService;
    }
    [HttpGet]
    [Route("{leagueId}")]
    public async Task<IActionResult> GetAllMatches(int leagueId)
    {
        var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        if (await _authorizationService.CheckIsAdmin(leagueId, userName))
        {
            var result = await _matchService.GetAllMatches();
            return Ok(result);
        }
        return Unauthorized();
    }
    [HttpPost]
    [Route("{leagueId}")]
    public async Task<IActionResult> AddLeagueBets(int leagueId, [FromBody] List<LeagueBetDTO> model)
    {
        var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        if (await _authorizationService.CheckIsAdmin(leagueId, userName))
        {
            var result = await _betService.AddLeagueBets(model, userName, leagueId);
            return Ok(result);
        }
        return Unauthorized();
    }
    [HttpGet]
    [Route("{leagueId}")]
    public async Task<IActionResult> GetAllLeagueBets(int leagueId)
    {
        var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        if (await _authorizationService.CheckIsUser(leagueId, userName))
        {
            var result = await _betService.GetALlLeagueBets(leagueId);
            return Ok(result);
        }
        return Unauthorized();
    }
}