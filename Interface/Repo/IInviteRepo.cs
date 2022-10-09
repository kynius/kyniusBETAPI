using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IInviteRepo
{
    Task<Invite> SendLeagueInviteToUser(InviteDTO model);
    Task<List<Invite>> GetAllInvitesByUserId(string userId, bool received, bool onlyWaiting = false);
    Task<Invite?> GetInviteById(int id);
    Task<Invite?> AcceptInvite(int id);
    Task<Invite?> RejectInvite(int id);
}