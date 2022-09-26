using kyniusBETAPI.Data;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model.Match;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class TeamRepo : ITeamRepo
{
    private readonly BetDB _db;

    public TeamRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<TeamsDTO> CheckTeamsInBase(TeamsDTO model)
    {
        
            var home = await _db.Team.FirstOrDefaultAsync(x => x.ApiId == model.Home.ApiId);
            var away = await _db.Team.FirstOrDefaultAsync(x => x.ApiId == model.Away.ApiId);
            if (home == null)
            {
                var homeTeam = await AddTeamToDb(model.Home);
                model.Home = homeTeam;
            }
            else
            {
                model.Home = home;
            }
            if (away == null)
            {
                var awayTeam = await AddTeamToDb(model.Away);
                model.Away = awayTeam;
            }
            else
            {
                model.Away = away;
            }
            return model;
    }

    public async Task<Team> AddTeamToDb(Team model)
    {
        await _db.Team.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }
}