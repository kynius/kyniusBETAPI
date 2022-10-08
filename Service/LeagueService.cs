using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model;

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

    public async Task<League> AddLeagueToBase(LeagueDTO model)
    {
        var league = await _leagueRepo.AddLeagueToBase(model);
        var user = await _userRepo.GetUserByUserName(model.UserName);
        await _leagueRepo.AddLeagueUserToBase(user, league, true);
        return league;
    }

    public async Task<List<LeagueViewModel>> GetLeaguesByUserName(string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var leagues = await _leagueRepo.GetAllLeaguesByUserId(user.Id);
        return leagues;
    }
}