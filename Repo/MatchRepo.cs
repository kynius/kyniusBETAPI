using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace kyniusBETAPI.Repo;

public class MatchRepo : IMatchRepo
{
    private readonly BetDB _db;
    public MatchRepo(BetDB db)
    {
        _db = db;
    }

    public async Task<Match> CheckMatchInBase(Match model)
    {
        var match = _db.Match.FirstOrDefault(x => x.ApiId == model.ApiId);
        if (match == null)
        {
            match = await AddMatchToBase(model);
            return match;
        }

        match.Score = model.Score;
        match.Status = model.Status;
        model.Goals = model.Goals;
        match = UpdateMatch(match);
        return match;
    }

    public Match UpdateMatch(Match match)
    {
        _db.Match.Entry(match).State = EntityState.Modified;
        _db.SaveChanges();
        return match;
    }

    public async Task<Match> AddMatchToBase(Match model)
    {
        await _db.Match.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<Match?> GetMatchById(int id)
    {
        var match = await _db.Match.Include(x => x.Away).Include(x => x.Home).FirstOrDefaultAsync(x => x.Id == id);
        return match ?? null;
    }

    public async Task<List<Match>> GetAllMatches()
    {
        return await _db.Match.Where(x => x.Date > DateTime.Now).Include(x => x.Home).Include(x => x.Away).Include(x => x.Goals).Include(x => x.Score).ToListAsync();
    }
}