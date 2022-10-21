using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IScoreRepo
{
    Task<Score> CheckScoreInBase(Score model);
    Task<Score> CheckWhenGoalsWasScored(Score model);
    Task<Score> AddScoreToBase(Score model);
}