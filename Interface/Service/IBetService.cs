using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Interface.Service;

public interface IBetService
{
    Task<Response> AddBet(BetDTO model, int leagueId, string userName);
    Task<Response> GetAllUserBetsInLeague(int leagueId, string userName);
}