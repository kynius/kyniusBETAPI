using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IMatchRepo
{
    public Task<Match> CheckMatchInBase(Match model);
    public Task<Match> AddMatchToBase(Match model);
}