using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface ILeagueRepo
{
    Task<League> AddLeagueToBase(LeagueDTO model);
    Task AddLeagueUserToBase(User user, League league);
}