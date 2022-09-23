using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data;
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
        var match = await _db.Match.FirstOrDefaultAsync(x => x.ApiId == model.ApiId);
        if (match == null)
        {
            match = await AddMatchToBase(model);
        }
        return match;
    }

    public async Task<Match> AddMatchToBase(Match model)
    {
        await _db.Match.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }
}