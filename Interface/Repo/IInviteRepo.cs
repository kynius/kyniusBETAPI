using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IInviteRepo
{
    Task<InviteViewModel> SendLeagueInviteToUser(InviteDTO model);
    Task<List<InviteViewModel>> GetAllInvitesByUserId(string userId, bool received, bool onlyWaiting = false);
    Task<Invite?> GetInviteById(int id);
    Task<InviteViewModel?> AcceptInvite(int id);
    Task<InviteViewModel?> RejectInvite(int id);
}