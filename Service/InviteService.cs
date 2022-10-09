using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model;
using kyniusBETAPI.Repo;

namespace kyniusBETAPI.Service;

public class InviteService : IInviteService
{
    private readonly IUserRepo _userRepo;
    private readonly IInviteRepo _inviteRepo;
    public InviteService(IUserRepo userRepo, IInviteRepo inviteRepo)
    {
        _userRepo = userRepo;
        _inviteRepo = inviteRepo;
    }
    public async Task<Response> SendInvite(int leagueId, string invitedUserName, string invitingUserName)
    {
        var invite = new InviteDTO()
        {
            LeagueId = leagueId
        };
        var invitingUser = await _userRepo.GetUserByUserName(invitingUserName);
        var invitedUser = await _userRepo.GetUserByUserName(invitedUserName);
        invite.InvitedUserId = invitedUser.Id;
        invite.InvitingUserId = invitingUser.Id;
        var mappedInvite = await _inviteRepo.SendLeagueInviteToUser(invite);
        return new Response
        {
            IsSucceeded = true,
            Message = mappedInvite,
            ResponseNumber = StatusCodes.Status201Created
        };
    }

    public async Task<List<Invite>> GetAllInvites(string userName, bool received, bool onlyWaiting = false)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var invites = await _inviteRepo.GetAllInvitesByUserId(user.Id, received, onlyWaiting);
        return invites;
    }
}