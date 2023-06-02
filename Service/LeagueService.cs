using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;

namespace kyniusBETAPI.Service;

public class LeagueService : ILeagueService
{
    private readonly ILeagueRepo _leagueRepo;
    private readonly IUserRepo _userRepo;

    public LeagueService(ILeagueRepo leagueRepo, IUserRepo userRepo)
    {
        _leagueRepo = leagueRepo;
        _userRepo = userRepo;
    }

    public async Task<Response> AddLeagueToBase(LeagueDTO model)
    {
        var league = await _leagueRepo.AddLeagueToBase(model);
        var user = await _userRepo.GetUserByUserName(model.UserName);
        await _leagueRepo.AddLeagueUserToBase(user, league, true);
        return new Response
        {
            IsSucceeded = true,
            Message = new LeagueViewModel(league),
            ResponseNumber = StatusCodes.Status201Created
        };
    }

    public async Task<List<LeagueViewModel>> GetLeaguesByUserName(string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var leagues = await _leagueRepo.GetAllLeaguesByUserId(user.Id);
        return leagues;
    }
}