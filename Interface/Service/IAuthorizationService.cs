namespace kyniusBETAPI.Interface.Service;

public interface IAuthorizationService
{
    Task<bool> CheckIsAdmin(int leagueId, string userName);
    Task<bool> CheckIsUser(int leagueId, string userName);
}