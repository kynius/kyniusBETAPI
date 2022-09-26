using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model.Match;
using Newtonsoft.Json;
namespace kyniusBETAPI.Builder;

public class AdminBuilder
{
    private readonly IRequestRepo _requestRepo;
    private readonly IMatchService _matchService;
    public AdminBuilder(IRequestRepo requestRepo, IMatchService matchService)
    {
        _requestRepo = requestRepo;
        _matchService = matchService;
    }

    public async Task<List<Match>> Build()
    {
        var dates = new List<string>();
        var date = DateTime.Now.AddDays(-1);
        var d = date.AddDays(6).ToString("yyyy-MM-dd");
        var query = $"fixtures?to={d}&season=2022&league=5&from={date.ToString("yyyy-MM-dd")}"; 
        var response = await _requestRepo.Request<List<MatchDTO>>(query);
        return(await _matchService.AddMatchesToDataBase(response));
    }
}
