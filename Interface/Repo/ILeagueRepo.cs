using System.Security.Claims;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface ILeagueRepo
{
    Task<League> AddLeagueToBase(LeagueDTO model);
    Task AddLeagueUserToBase(User user, League league, bool isAdmin);
    Task<List<LeagueViewModel>> GetAllLeaguesByUserId(string userId);
    Task<List<Claim>> GetClaimByLeagueUserList(List<LeagueUser> leagueUsers);
    Task<List<LeagueUser>> GetLeagueUsersByUserId(string userId);
}