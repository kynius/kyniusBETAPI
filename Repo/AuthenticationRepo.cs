using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

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

    public async Task<Response> Register(UserRegisterDTO model)
    {
        var userExist = await _userManager.FindByNameAsync(model.UserName);
        if (userExist != null)
        {
            return (new Response{IsSucceeded = false, Message = "User already exists!", ResponseNumber = StatusCodes.Status500InternalServerError});
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
            return (new Response{IsSucceeded = false, Message = "User creation failed" + result.Errors.ToString(), ResponseNumber = StatusCodes.Status500InternalServerError});
        }
        return new Response
        {
            IsSucceeded = true,
            Message = "User creation succeeded",
            ResponseNumber = StatusCodes.Status201Created
        };
    }

    public async Task<Response> Login(UserLoginDTO model)
    {
        var user = new User();
        if (model.UserName.Contains("@"))
        {
            user = await _userManager.FindByEmailAsync(model.UserName);
        }
        else
        {
            user = await _userManager.FindByNameAsync(model.UserName);
        }

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var secret = _configuration["JWT:Secret"];
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );
            var encryptedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new Response { Token = encryptedToken, Message = "User is loged in", IsSucceeded = true, ResponseNumber = StatusCodes.Status202Accepted};
        }

        return new Response
        {
            Message = "Login or password is valid", 
            ResponseNumber = StatusCodes.Status409Conflict,
            IsSucceeded = false
        };
    }
}