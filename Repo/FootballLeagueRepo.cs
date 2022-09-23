using kyniusBETAPI.Data;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model.Match;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class FootballLeagueRepo : IFootballLeagueRepo
{
    private readonly BetDB _db;

    public FootballLeagueRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<FootballLeague> CheckFootballLeagueInBase(FootballLeague model)
    {
        var footballLeague = await _db.FootballLeague.FirstOrDefaultAsync(x => x.ApiId == model.ApiId);
        if (footballLeague == null)
        {
            footballLeague = await AddFootballLeague(model);
        }
        return footballLeague;
    }

    public async Task<FootballLeague> AddFootballLeague(FootballLeague model)
    {
        await _db.FootballLeague.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }
}