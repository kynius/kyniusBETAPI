using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Service;

public interface IMatchService
{
    Task<List<Match>> AddMatchesToDataBase(List<MatchDTO> matches);
}