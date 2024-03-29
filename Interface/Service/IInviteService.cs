using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.ViewModel;

namespace kyniusBETAPI.Interface.Service;

public interface IInviteService
{
    Task<Response> SendInvite(int leagueId, string invitedUserName, string invitingUserName);
    Task<List<InviteViewModel>> GetAllInvites(string userName, bool received, bool onlyWaiting = false);
    Task<Response> AcceptInvite(int id, string userName);
    Task<Response> RejectInvite(int id, string userName);
}