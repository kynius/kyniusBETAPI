using System.Security.Claims;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface ILeagueRepo
{
    Task<League> GetLeagueById(int id);
    Task<League> AddLeagueToBase(LeagueDTO model);
    Task AddLeagueUserToBase(User user, League league, bool isAdmin);
    Task<List<LeagueViewModel>> GetAllLeaguesByUserId(string userId);
    Task<List<LeagueUser>> GetLeagueUsersByUserId(string userId);
    Task<LeagueUser?> GetLeagueUserByUserIdAndLeagueId(string userId, int leagueId);
    Task AddPoints(Bet bet);
}