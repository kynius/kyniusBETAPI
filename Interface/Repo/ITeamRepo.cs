using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface ITeamRepo
{
    Task<TeamsDTO> CheckTeamsInBase(TeamsDTO model);
    Task<Team> AddTeamToDb(Team model);

}