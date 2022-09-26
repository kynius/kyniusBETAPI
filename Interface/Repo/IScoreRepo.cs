using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IScoreRepo
{
    public Task<Score> CheckScoreInBase(Score model);
    public Task<Score> CheckWhenGoalsWasScored(Score model);
    public Task<Score> AddScoreToBase(Score model);
}