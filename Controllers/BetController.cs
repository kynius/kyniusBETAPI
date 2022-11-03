using System.Security.Claims;
using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = kyniusBETAPI.Interface.Service.IAuthorizationService;

namespace kyniusBETAPI.Controllers;
[Authorize]
public class BetController : ApiController
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IBetService _betService;
    public BetController(IAuthorizationService authorizationService, IBetService betService)
    {
        _authorizationService = authorizationService;
        _betService = betService;
    }
    [HttpPost]
    [Route("{leagueId}")]
    public async Task<IActionResult> AddBet(int leagueId, [FromBody] List<BetDTO> model)
    {
        var userName = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        if (userName != null && ModelState.IsValid)
        {
            if (await _authorizationService.CheckIsUser(leagueId, userName))
            {
                var response = await _betService.AddBet(model, leagueId, userName);
                return Ok(response);
            }
            return BadRequest(new Response
            {
                IsSucceeded = false,
                Message = "Forbidden",
                ResponseNumber = StatusCodes.Status403Forbidden
            });
        }
        return BadRequest(new Response
        {
            IsSucceeded = false,
            Message = ModelState,
            ResponseNumber = StatusCodes.Status400BadRequest
        });
    }

    [HttpGet]
    [Route("{leagueId}")]
    public async Task<IActionResult> GetAllBets(int leagueId)
    {
        var userName = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        if (userName != null && await _authorizationService.CheckIsUser(leagueId, userName))
        {
            var bets = await _betService.GetAllUserBetsInLeague(leagueId, userName);
            return Ok(bets);
        }
        return BadRequest(new Response
        {
            IsSucceeded = false,
            Message = "Forbidden",
            ResponseNumber = StatusCodes.Status403Forbidden
        });
    }
}