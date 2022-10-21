using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;

namespace kyniusBETAPI.Service;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepo _userRepo;
    private readonly ILeagueRepo _leagueRepo;

    public AuthorizationService(IUserRepo userRepo, ILeagueRepo leagueRepo)
    {
        _userRepo = userRepo;
        _leagueRepo = leagueRepo;
    }

    public async Task<bool> CheckIsAdmin(int leagueId, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var leagueUser = await _leagueRepo.GetLeagueUserByUserIdAndLeagueId(user.Id, leagueId);
        if (leagueUser is { Role: UserRoles.Admin })
        {
            return true;
        }
        return false;
    }

    public async Task<bool> CheckIsUser(int leagueId, string userName)
    {
        var user = await _userRepo.GetUserByUserName(userName);
        var leagueUser = await _leagueRepo.GetLeagueUserByUserIdAndLeagueId(user.Id, leagueId);
        if (leagueUser is { Role: UserRoles.User })
        {
            return true;
        }
        if (leagueUser is { Role: UserRoles.Admin })
        {
            return true;
        }
        return false;
    }
}