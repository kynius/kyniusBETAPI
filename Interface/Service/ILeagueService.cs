using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Service;

public interface ILeagueService
{
    Task<League> AddLeagueToBase(LeagueDTO model);
}