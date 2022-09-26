using kyniusBETAPI.Data;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Repo;

public class LeagueRepo : ILeagueRepo
{
    private readonly BetDB _db;

    public LeagueRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<League> AddLeagueToBase(LeagueDTO model)
    {
        var league = new League(model);
        await _db.League.AddAsync(league);
        await _db.SaveChangesAsync();
        return league;
    }
    public async Task AddLeagueUserToBase(User user, League league)
    {
        var leagueUser = new LeagueUser
        {
            UserId = user.Id,
            LeagueId = league.Id
        };
        await _db.LeagueUser.AddAsync(leagueUser);
        await _db.SaveChangesAsync();
    }
}