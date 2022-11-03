using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IBetRepo
{
    Task<Bet> AddBet(Bet model);
    Bet UpdateBet(Bet model);
    Task<LeagueBet> AddLeagueBet(LeagueBetDTO model, string userId ,int leagueId, DateTime matchDate);
    Task<List<Bet>> GetAllUserBetsInLeague(string userId, int leagueId);
    Task<List<BetViewModel>> GetAllLeagueBets(int leagueId);
    Task<List<Bet>> GetAllBets(DateTime? dateTime);
    Task<BetViewModel> CheckBet(Bet model);
}