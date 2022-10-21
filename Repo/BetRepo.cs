using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class BetRepo : IBetRepo
{
    private readonly BetDB _db;

    public BetRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<Bet> AddBet(Bet model)
    {
        await _db.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<List<Bet>> GetAllUserBetsInLeague(string userId, int leagueId)
    {
        return await _db.Bet.Where(x => x.LeagueUser.LeagueId == leagueId && x.LeagueUser.UserId == userId)
            .Include(x => x.LeagueUser).Include(x => x.Match).ThenInclude(x => x.Home)
            .Include(x => x.Match).ThenInclude(x => x.Away).ToListAsync();
    }
}