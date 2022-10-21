using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IMatchRepo
{
    Task<Match> CheckMatchInBase(Match model);
    Task<Match> AddMatchToBase(Match model);
    Task<Match?> GetMatchById(int id);
}