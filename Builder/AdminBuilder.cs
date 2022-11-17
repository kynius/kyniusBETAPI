using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model.Match;
using Newtonsoft.Json;
namespace kyniusBETAPI.Builder;

public class AdminBuilder
{
    private readonly IRequestRepo _requestRepo;
    private readonly IMatchService _matchService;
    private readonly IBetService _betService;
    public AdminBuilder(IRequestRepo requestRepo, IMatchService matchService, IBetService betService)
    {
        _requestRepo = requestRepo;
        _matchService = matchService;
        _betService = betService;
    }

    public async Task<List<Match>> Build()
    {
        var dates = new List<string>();
        var date = DateTime.Now;
        var d = date.AddDays(6).ToString("yyyy-MM-dd");
        var query = $"fixtures?to={d}&season=2022&league=1&from={date.ToString("yyyy-MM-dd")}"; 
        var response = await _requestRepo.Request<List<MatchDTO>>(query);
        return(await _matchService.AddMatchesToDataBase(response));
    }
    public async Task<List<BetViewModel>> CheckBets()
    {
        var date = DateTime.Now;
        var query = $"fixtures?season=2022&league=2&date={date.ToString("yyyy-MM-dd")}"; 
        var response = await _requestRepo.Request<List<MatchDTO>>(query);
        var matches = await _matchService.AddMatchesToDataBase(response);
        return(await _betService.CheckAllBets(matches));
    }
}
