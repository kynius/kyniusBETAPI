using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IBetRepo
{
    Task<Bet> AddBet(Bet model);
    Task<List<Bet>> GetAllUserBetsInLeague(string userId, int leagueId);
}