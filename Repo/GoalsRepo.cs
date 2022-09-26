using kyniusBETAPI.Data;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model.Match;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class GoalsRepo : IGoalsRepo
{
    private readonly BetDB _db;

    public GoalsRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<Goals> CheckGoalsInBase(Goals model)
    {
        var goals = await _db.Goals.FirstOrDefaultAsync(x => x.Home == model.Home && x.Away == model.Away);
        if (goals == null)
        {
            var modelFromDb = await AddGoalsToBase(model);
            return modelFromDb;
        }
        return goals;
    }

    public async Task<Goals> AddGoalsToBase(Goals model)
    {
        await _db.Goals.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }
}