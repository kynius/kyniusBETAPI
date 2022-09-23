using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Service;

public interface IScoreService
{
    public Task<Score> CheckScoreInBase(Score model);
}