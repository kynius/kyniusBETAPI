using kyniusBETAPI.Data;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Repo;

public class ScoreRepo : IScoreRepo
{
    private readonly BetDB _db;
    private readonly IGoalsRepo _goalsRepo;
    public ScoreRepo(BetDB db, IGoalsRepo goalsRepo)
    {
        _db = db;
        _goalsRepo = goalsRepo;
    }

    public async Task<Score> CheckScoreInBase(Score model)
    {
        model = await CheckWhenGoalsWasScored(model);
        var score = await AddScoreToBase(model);
        return score;
    }
    public async Task<Score> AddScoreToBase(Score model)
    {
        await _db.Score.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<Score> CheckWhenGoalsWasScored(Score model)
    {
        if (model.Halftime.Home == null || model.Halftime.Away == null || model.Fulltime.Home == null ||
            model.Fulltime.Away == null)
        {
            return model;
        }
        model.GoalsInFirsthalf = model.Halftime;
        model.GoalsInSecondhalf.Home = model.Fulltime.Home - model.Halftime.Home;
        model.GoalsInSecondhalf.Away = model.Fulltime.Away - model.Halftime.Away;
        //First Half
        if (model.GoalsInFirsthalf.Home == model.GoalsInFirsthalf.Away)
        {
            model.IsHomeWinnerFirstHalf = null;
            model.IsAwayWinnerFirstHalf = null;
        }

        if (model.GoalsInFirsthalf.Home > model.GoalsInFirsthalf.Away)
        {
            model.IsHomeWinnerFirstHalf = true;
            model.IsAwayWinnerFirstHalf = false;
        }

        if (model.GoalsInFirsthalf.Home < model.GoalsInFirsthalf.Away)
        {
            model.IsHomeWinnerFirstHalf = false;
            model.IsAwayWinnerFirstHalf = true;
        }

        //Second Half
        if (model.GoalsInSecondhalf.Home == model.GoalsInSecondhalf.Away)
        {
            model.IsHomeWinnerSecondHalf = null;
            model.IsAwayWinnerSecondHalf = null;
        }

        if (model.GoalsInSecondhalf.Home > model.GoalsInSecondhalf.Away)
        {
            model.IsHomeWinnerSecondHalf = true;
            model.IsAwayWinnerSecondHalf = false;
        }

        if (model.GoalsInSecondhalf.Home < model.GoalsInSecondhalf.Away)
        {
            model.IsHomeWinnerSecondHalf = false;
            model.IsAwayWinnerSecondHalf = true;
        }

        //fullmatch
        if (model.Fulltime.Home == model.Fulltime.Away)
        {
            model.IsHomeWinnerFullMatch = null;
            model.IsAwayWinnerFullMatch = null;
        }

        if (model.Fulltime.Home > model.Fulltime.Away)
        {
            model.IsHomeWinnerFullMatch = true;
            model.IsAwayWinnerFullMatch = false;
        }

        if (model.Fulltime.Home < model.Fulltime.Away)
        {
            model.IsHomeWinnerFullMatch = false;
            model.IsAwayWinnerFullMatch = true;
        }
        model.GoalsInFirsthalf = await _goalsRepo.CheckGoalsInBase(model.GoalsInFirsthalf);
        model.GoalsInSecondhalf = await _goalsRepo.CheckGoalsInBase(model.GoalsInSecondhalf);
        return model;
    }
}