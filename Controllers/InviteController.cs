using System.Security.Claims;
using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;

public class InviteController : ApiController
{
    private readonly IInviteService _inviteService;

    public InviteController(IInviteService inviteService)
    {
        _inviteService = inviteService;
    }

    [HttpPost]
    [Route("{leagueId}")]
    [Authorize(Policy = "IsLeagueAdmin")]
    public async Task<IActionResult> SendInvite(int leagueId, [FromBody] string invitedUserName)
    {
        if (ModelState.IsValid)
        {
            var response = await _inviteService.SendInvite(leagueId, invitedUserName,
                User.Claims.First(x => x.Type == ClaimTypes.Name).Value);
            return Ok(response);
        }
        return BadRequest(new Response
        {
            IsSucceeded = false,
            Message = ModelState,
            ResponseNumber = StatusCodes.Status404NotFound
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
}