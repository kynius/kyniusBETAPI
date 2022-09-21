using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationRepo _authenticationRepo;

    public AuthenticationController(AuthenticationRepo authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO model)
    {
        var response = await _authenticationRepo.Register(model);
        return Ok(response);
    }
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
    {
        var response = await _authenticationRepo.Login(model);
        return Ok(response);
    }
}