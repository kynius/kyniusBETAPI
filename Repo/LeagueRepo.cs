using System.Security.Claims;
using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class LeagueRepo : ILeagueRepo
{
    private readonly BetDB _db;

    public LeagueRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<League> GetLeagueById(int id)
    {
        return await _db.League.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<League> AddLeagueToBase(LeagueDTO model)
    {
        var league = new League(model);
        await _db.League.AddAsync(league);
        await _db.SaveChangesAsync();
        return league;
    }
    public async Task AddLeagueUserToBase(User user, League league, bool isAdmin)
    {
        var leagueUser = new LeagueUser
        {
            LeagueId = league.Id,
            UserId = user.Id,
            League = league,
            User = user
        };
        if (isAdmin is true)
        {
            leagueUser.Role = UserRoles.Admin;
        }
        else
        {
            leagueUser.Role = UserRoles.User;
        }
        await _db.LeagueUser.AddAsync(leagueUser);
        await _db.SaveChangesAsync();
    }
    public async Task<List<LeagueViewModel>> GetAllLeaguesByUserId(string userId)
    {
        var leaguesFromDb = await _db.League.Include(x => x.LeagueUser).ToListAsync();
        var leagues = new List<League>();
        foreach (var league in leaguesFromDb)
        {
            foreach (var leagueUser in league.LeagueUser)
            {
                if (leagueUser.UserId == userId)
                {
                    if (leagues.FirstOrDefault(x => x == league) == null)
                    {
                        leagues.Add(league);
                    }
                }
            }
        }
        var mappedLeagues = new List<LeagueViewModel>();
        foreach (var l in leagues)
        {
            mappedLeagues.Add(new LeagueViewModel(l));
        }
        return mappedLeagues;
    }

    public async Task<List<Claim>> GetClaimByLeagueUserList(List<LeagueUser> leagueUsers)
    {
        var claims = new List<Claim>();
        foreach (var lu in leagueUsers) 
        {
            if (lu.Role == UserRoles.Admin)
            {
                claims.Add(new Claim(lu.LeagueId.ToString(), UserRoles.Admin));
            }
            else
            {
                claims.Add(new Claim(lu.LeagueId.ToString(), UserRoles.User));
            }
        }
        return claims;
    }
    public async Task<List<LeagueUser>> GetLeagueUsersByUserId(string userId)
    {
        return await _db.LeagueUser.Where(x => x.UserId == userId).ToListAsync();
    }
}