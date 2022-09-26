using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model.Match;
using kyniusBETAPI.Repo;

namespace kyniusBETAPI.Service;

public class ScoreService : IScoreService
{
    private readonly IScoreRepo _scoreRepo;
    private readonly IGoalsRepo _goalsRepo;

    public ScoreService(IScoreRepo scoreRepo, IGoalsRepo goalsRepo)
    {
        _scoreRepo = scoreRepo;
        _goalsRepo = goalsRepo;
    }

    public async Task<Score> CheckScoreInBase(Score model)
    {
        model.Halftime = await _goalsRepo.CheckGoalsInBase(model.Halftime);
        model.Fulltime = await _goalsRepo.CheckGoalsInBase(model.Fulltime);
        model.Extratime = await _goalsRepo.CheckGoalsInBase(model.Extratime);
        model.Penalty = await _goalsRepo.CheckGoalsInBase(model.Penalty);
        model = await _scoreRepo.CheckWhenGoalsWasScored(model);
        model.GoalsInFirsthalf = await _goalsRepo.CheckGoalsInBase(model.GoalsInFirsthalf);
        model.GoalsInSecondhalf = await _goalsRepo.CheckGoalsInBase(model.GoalsInSecondhalf);
        var score = await _scoreRepo.CheckScoreInBase(model);
        return score;
    }
}