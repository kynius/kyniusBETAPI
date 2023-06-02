using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IMatchRepo
{
    Task<Match> CheckMatchInBase(Match model);
    Match UpdateMatch(Match match);
    Task<Match> AddMatchToBase(Match model);
    Task<Match?> GetMatchById(int id);
    Task<List<Match>> GetAllMatches();
}