using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Service;

public interface IMatchService
{
    Task<List<Match>> AddMatchesToDataBase(List<MatchDTO> matches);
    Task<Response> GetAllMatches();
}