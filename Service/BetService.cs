using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Service;

public class BetService : IBetService
{
    private readonly ILeagueRepo _leagueRepo;
    private readonly IBetRepo _betRepo;
    private readonly IUserRepo _userRepo;
    private readonly IMatchRepo _matchRepo;
    public BetService(ILeagueRepo leagueRepo, IBetRepo betRepo, IUserRepo userRepo, IMatchRepo matchRepo)
    {
        _leagueRepo = leagueRepo;
        _betRepo = betRepo;
        _userRepo = userRepo;
        _matchRepo = matchRepo;
    }

    public async Task<Response> AddBet(List<BetDTO> model, int leagueId, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var bets = new List<BetViewModel>();
        foreach (var m in model)
        {
            if (m.DateToBet > DateTime.Now)
            {
                var bet = new Bet(m);
                bet.UserId = user.Id;
                var addedBet = await _betRepo.AddBet(bet);
                addedBet.LeagueBet = await _betRepo.GetLeagueBetById(m.LeagueBetId);
                var mappedModel = new BetViewModel(addedBet);
                bets.Add(mappedModel);
            }
        }
        return new Response
        {
            IsSucceeded = true,
            Message = bets,
            ResponseNumber = StatusCodes.Status202Accepted
        };
    }
    public async Task<Response> AddLeagueBets(List<LeagueBetDTO> model, string userName, int leagueId)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        foreach (var m in model)
        {
            var match = await _matchRepo.GetMatchById(m.MatchId.GetValueOrDefault());
            if (match != null)
            {
                 await _betRepo.AddLeagueBet(m, user.Id ,leagueId, match.Date.GetValueOrDefault());
            }
        }
        return new Response
        {
            ResponseNumber = StatusCodes.Status202Accepted,
            IsSucceeded = true,
            Message = "League Bets Added"
        };
    }
    public async Task<Response> GetAllUserBetsInLeague(int leagueId, string userName, bool onlyActive)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var userBets = await _betRepo.GetAllUserBetsInLeague(user.Id, leagueId, onlyActive);
        var mappedUserBets = userBets.Select(ub => new BetViewModel(ub)).ToList();
        return new Response
        {
            IsSucceeded = true,
            Message = mappedUserBets,
            ResponseNumber = StatusCodes.Status202Accepted
        };
    }

    public async Task<Response> GetALlLeagueBets(int leagueId)
    {
        var leagueBets = await _betRepo.GetAllLeagueBets(leagueId);
        if (leagueBets.Any())
        {
            return new Response
            {
                IsSucceeded = true,
                Message = leagueBets,
                ResponseNumber = StatusCodes.Status202Accepted
            };
        }

        return new Response
        {
            IsSucceeded = true,
            Message = "League have no active bets",
            ResponseNumber = StatusCodes.Status204NoContent
        };
    }
    public async Task<List<BetViewModel>> CheckAllBets(List<Match> matches)
    {
        var mappedBets = new List<BetViewModel>();
        var bets = await _betRepo.GetAllBets();
        foreach (var b in bets)
        {
            mappedBets.Add(await _betRepo.CheckBet(b));
            await _leagueRepo.AddPoints(b);
        }
        return mappedBets;
    }

    public async Task<Response> GetAllBetTypes()
    {
        return new Response
        {
            IsSucceeded = true,
            Message = await _betRepo.GetAllBetTypes(),
            ResponseNumber = StatusCodes.Status200OK
        };
    }
}