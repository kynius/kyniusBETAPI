using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Service;

public interface IScoreService
{
    Task<Score> CheckScoreInBase(Score model);
}