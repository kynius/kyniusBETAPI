using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;

namespace kyniusBETAPI.Service;

public class InviteService : IInviteService
{
    private readonly IUserRepo _userRepo;
    private readonly IInviteRepo _inviteRepo;
    private readonly ILeagueRepo _leagueRepo;
    public InviteService(IUserRepo userRepo, IInviteRepo inviteRepo, ILeagueRepo leagueRepo)
    {
        _userRepo = userRepo;
        _inviteRepo = inviteRepo;
        _leagueRepo = leagueRepo;
    }
    public async Task<Response> SendInvite(int leagueId, string invitedUserName, string invitingUserName)
    {
        var invite = new InviteDTO()
        {
            LeagueId = leagueId,
        };
        var invitingUser = await _userRepo.GetUserByUserName(invitingUserName);
        var invitedUser = await _userRepo.GetUserByUserName(invitedUserName);
        invite.InvitedUserId = invitedUser.Id;
        invite.InvitingUserId = invitingUser.Id;
        var mappedInvite = await _inviteRepo.SendLeagueInviteToUser(invite);
        var league = await _leagueRepo.GetLeagueById(leagueId);
        mappedInvite.LeagueName = league.Name;
        return new Response
        {
            IsSucceeded = true,
            Message = mappedInvite,
            ResponseNumber = StatusCodes.Status201Created
        };
    }

    public async Task<List<InviteViewModel>> GetAllInvites(string userName, bool received, bool onlyWaiting = false)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var invites = await _inviteRepo.GetAllInvitesByUserId(user.Id, received, onlyWaiting);
        return invites;
    }

    public async Task<Response> AcceptInvite(int id, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var invite = await _inviteRepo.GetInviteById(id);
        if (invite.InvitedUser == user)
        {
            if (invite.Status is not InviteStatus.Waiting)
            {
                return new Response
                {
                    Message = "Invite was rejected or accepted yet",
                    IsSucceeded = false,
                    ResponseNumber = StatusCodes.Status304NotModified
                };
            }
            if (invite != null && invite.InvitedUser != null && invite.League != null)
            {
                await _leagueRepo.AddLeagueUserToBase(invite.InvitedUser, invite.League, false);
            }
            var response = await _inviteRepo.AcceptInvite(id);
            return new Response
            {
                Message = response,
                IsSucceeded = true,
                ResponseNumber = StatusCodes.Status202Accepted
            };
        }
        return new Response
        {
            Message = "Unauthorized",
            IsSucceeded = false,
            ResponseNumber = StatusCodes.Status401Unauthorized
        };
    }

    public async Task<Response> RejectInvite(int id, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var invite = await _inviteRepo.GetInviteById(id);
        if (invite.InvitedUser == user)
        {
            if (invite.Status is not InviteStatus.Waiting)
            {
                return new Response
                {
                    Message = "Invite was rejected or accepted yet",
                    IsSucceeded = false,
                    ResponseNumber = StatusCodes.Status304NotModified
                };
            }
            var response = await _inviteRepo.RejectInvite(id);
            return new Response
            {
                Message = response,
                IsSucceeded = true,
                ResponseNumber = StatusCodes.Status202Accepted
            };
        }
        return new Response
        {
            Message = "Unauthorized",
            IsSucceeded = false,
            ResponseNumber = StatusCodes.Status401Unauthorized
        };
    }
}