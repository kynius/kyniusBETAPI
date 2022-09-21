using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace kyniusBETAPI.Repo;

public class AuthenticationRepo : IAuthenticationRepo
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthenticationRepo(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<Response> Register(UserDTO model)
    {
        var userExist = await _userManager.FindByNameAsync(model.UserName);
        if (userExist != null)
        {
            return (new Response{IsSucceeded = false, Message = "User already exists!", Error = StatusCodes.Status500InternalServerError});
        }

        var user = new User()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return (new Response{IsSucceeded = false, Message = "User creation failed" + result.Errors.ToString(), Error = StatusCodes.Status500InternalServerError});
        }
        return new Response
        {
            IsSucceeded = true,
            Message = "User creation succeeded"
        };
    }
}