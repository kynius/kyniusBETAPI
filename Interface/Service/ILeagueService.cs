using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Service;

public interface ILeagueService
{
    Task<Response> AddLeagueToBase(LeagueDTO model);
    Task<List<LeagueViewModel>> GetLeaguesByUserName(string userName);
}