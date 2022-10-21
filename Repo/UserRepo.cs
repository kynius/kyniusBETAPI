using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace kyniusBETAPI.Repo;

public class UserRepo : IUserRepo
{
    private readonly UserManager<User> _userManager;

    public UserRepo(UserManager<User> userManager)
    {
        _userManager = userManager;
    }


    public async Task<User> GetUserByUserName(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return user;
    }
}