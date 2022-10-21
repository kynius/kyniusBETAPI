using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model;

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

    public async Task<Response> AddBet(BetDTO model, int leagueId, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var leagueUser = await _leagueRepo.GetLeagueUserByUserIdAndLeagueId(user.Id, leagueId);
        var bet = new Bet(model);
        if(leagueUser != null)
            bet.LeagueUserId = leagueUser.Id;
        var match = await _matchRepo.GetMatchById(model.MatchId);
        if(match != null)
            bet.Match = match;
        var addedBet = await _betRepo.AddBet(bet);
        var mappedModel = new BetViewModel(addedBet);
        return new Response
        {
            IsSucceeded = true,
            Message = mappedModel,
            ResponseNumber = StatusCodes.Status202Accepted
        };
    }

    public async Task<Response> GetAllUserBetsInLeague(int leagueId, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var userBets = await _betRepo.GetAllUserBetsInLeague(user.Id, leagueId);
        var mappedUserBets = userBets.Select(ub => new BetViewModel(ub)).ToList();
        return new Response
        {
            IsSucceeded = true,
            Message = mappedUserBets,
            ResponseNumber = StatusCodes.Status202Accepted
        };
    }
}