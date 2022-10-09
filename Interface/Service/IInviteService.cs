using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Service;

public interface IInviteService
{
    Task<Response> SendInvite(int leagueId, string invitedUserName, string invitingUserName);
    Task<List<Invite>> GetAllInvites(string userName, bool received, bool onlyWaiting = false);
}