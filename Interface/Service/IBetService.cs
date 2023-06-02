using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Service;

public interface IBetService
{
    Task<Response> AddBet(List<BetDTO> model, int leagueId, string userName);
    Task<Response> AddLeagueBets(List<LeagueBetDTO> model, string userName, int leagueId);
    Task<Response> GetAllUserBetsInLeague(int leagueId, string userName, bool onlyActive);
    Task<Response> GetALlLeagueBets(int leagueId);
    Task<List<BetViewModel>> CheckAllBets(List<Match> matches);
    Task<Response> GetAllBetTypes();
}