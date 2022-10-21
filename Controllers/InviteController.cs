using System.Security.Claims;
using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = kyniusBETAPI.Interface.Service.IAuthorizationService;

namespace kyniusBETAPI.Controllers;

[Authorize]
public class InviteController : ApiController
{
    private readonly IInviteService _inviteService;
    private readonly IAuthorizationService _authorizationService;
    public InviteController(IInviteService inviteService, IAuthorizationService authorizationService)
    {
        _inviteService = inviteService;
        _authorizationService = authorizationService;
    }

    [HttpPost]
    [Route("{leagueId}")]
    public async Task<IActionResult> SendInvite(int leagueId, [FromBody] string invitedUserName)
    {
        if (await _authorizationService.CheckIsAdmin(leagueId, User.Claims.First(x => x.Type == ClaimTypes.Name).Value))
        {
            var response = await _inviteService.SendInvite(leagueId, invitedUserName,
                User.Claims.First(x => x.Type == ClaimTypes.Name).Value);
            return Ok(response);
        }
        return BadRequest(new Response
        {
            IsSucceeded = false,
            Message = ModelState,
            ResponseNumber = StatusCodes.Status401Unauthorized
        });
    }
    [HttpGet]
    public async Task<IActionResult> GetAllReceivedWaitingInvites()
    {
        var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        var response = await _inviteService.GetAllInvites(userName, received:true, onlyWaiting:true);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSentWaitingInvites()
    {
        var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        var response = await _inviteService.GetAllInvites(userName, received:false, onlyWaiting:true);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AcceptInvite(int id)
    {
        var response = await _inviteService.AcceptInvite(id, User.Claims.First(x => x.Type == ClaimTypes.Name).Value);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> RejectInvite(int id)
    {
        var response = await _inviteService.RejectInvite(id, User.Claims.First(x => x.Type == ClaimTypes.Name).Value);
        return Ok(response);
    }
}