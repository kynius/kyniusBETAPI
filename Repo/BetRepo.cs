using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.EntityFrameworkCore;
using BetTypes = kyniusBETAPI.AbstractModel.BetTypes;

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
    public Bet UpdateBet(Bet model)
    {
        var m = _db.Bet.FirstOrDefault(x => x.Id == model.Id);
        if (m != null)
        {
            m.IsCorrect = model.IsCorrect;
            _db.Bet.Entry(m).State = EntityState.Modified;
            _db.SaveChanges();
            return m;
        }

        return model;
    }
    public async Task<LeagueBet> AddLeagueBet(LeagueBetDTO model,string userId ,int leagueId, DateTime matchDate)
    {
        var leagueBet = new LeagueBet(model);
        leagueBet.LeagueId = leagueId;
        leagueBet.DateToBet = matchDate.AddHours(-2);
        var leagueBetFromDB = await CheckLeagueBet(leagueId, model.MatchId.GetValueOrDefault());
        if (leagueBetFromDB != null)
        {
            return leagueBetFromDB;
        }
        await _db.LeagueBet.AddAsync(leagueBet);
        await _db.SaveChangesAsync();
        return leagueBet;
    }

    public async Task<List<Bet>> GetAllUserBetsInLeague(string userId, int leagueId)
    {
        return await _db.Bet.Where(x => x.UserId == userId).Include(x => x.LeagueBet).Where(x => x.LeagueBet.LeagueId == leagueId).ToListAsync();
    }

    public async Task<List<BetViewModel>> GetAllLeagueBets(int leagueId)
    {
        var betList = new List<BetViewModel>();
        var leagueBets = await _db.LeagueBet.Include(x => x.BetType).Include(x => x.Match).ThenInclude(x => x.Home).Include(x => x.Match).ThenInclude(x => x.Away).Where(x => x.LeagueId == leagueId).Where(x => x.DateToBet > DateTime.Now).ToListAsync();
        foreach (var lb in leagueBets)
        {
            betList.Add(new BetViewModel
            {
                Id = lb.Id,
                HomeTeam = lb.Match.Home,
                AwayTeam = lb.Match.Away,
                BetType = lb.BetType,
                DateTime = lb.Match.Date.GetValueOrDefault(),
                DateToBet = lb.DateToBet,
                MatchId = lb.Match.Id
            });
        }
        return betList;
    }

    public async Task<List<Bet>> GetAllBets(DateTime? dateTime)
    {
        return await _db.Bet.Where(x => x.LeagueBet.DateToBet.Date == dateTime).Include(x => x.LeagueBet).ToListAsync();
    }

    public async Task<BetViewModel> CheckBet(Bet model)
    {
        if (model.LeagueBet.BetType.Name is BetTypes.Winner)
        {
            if (model.LeagueBet.Match.Home.ApiId == int.Parse(model.Value))
            {
                model.IsCorrect = model.LeagueBet.Match.Score.IsHomeWinnerFullMatch;
            }
            if (model.LeagueBet.Match.Away.ApiId == int.Parse(model.Value))
            {
                model.IsCorrect = model.LeagueBet.Match.Score.IsAwayWinnerFullMatch;
            }
        }
        if (model.LeagueBet.BetType.Name is BetTypes.BothTeamToScore)
        {
            if (bool.Parse(model.Value))
            {
                model.IsCorrect = model.LeagueBet.Match.Goals.Away != 0 && model.LeagueBet.Match.Goals.Home != 0;
            }
            else if (!bool.Parse(model.Value))
            {
                model.IsCorrect = model.LeagueBet.Match.Goals.Away == 0 && model.LeagueBet.Match.Goals.Home == 0;
            }
            else
            {
                model.IsCorrect = false;
            }
        }
        if (model.LeagueBet.BetType.Name is BetTypes.Score)
        {
            model.IsCorrect = model.Value ==
                              String.Concat(model.LeagueBet.Match.Goals.Away, ":", model.LeagueBet.Match.Goals.Home);
        }

        model = UpdateBet(model);
        return new BetViewModel(model);
    }

    public async Task<List<BetType>> GetAllBetTypes()
    {
        return await _db.BetType.ToListAsync();
    }

    private async Task<LeagueBet?> CheckLeagueBet(int leagueId, int matchId)
    {
        var leagueBet = await _db.LeagueBet.FirstOrDefaultAsync(x => x.MatchId == matchId && x.LeagueId == leagueId);
        return leagueBet;
    }
}