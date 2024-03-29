using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IBetRepo
{
    Task<Bet> AddBet(Bet model);
    Bet UpdateBet(Bet model);
    Task<LeagueBet> AddLeagueBet(LeagueBetDTO model, string userId ,int leagueId, DateTime matchDate);
    Task<List<Bet>> GetAllUserBetsInLeague(string userId, int leagueId, bool onlyActive);
    Task<List<BetViewModel>> GetAllLeagueBets(int leagueId);
    Task<List<Bet>> GetAllBets();
    Task<BetViewModel> CheckBet(Bet model);
    Task<List<BetType>> GetAllBetTypes();
    Task<LeagueBet> GetLeagueBetById(int id);
}