using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;
public class AuthenticationController : ApiController
{
    private readonly AuthenticationRepo _authenticationRepo;

    public AuthenticationController(AuthenticationRepo authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO model)
    {
        var response = await _authenticationRepo.Register(model);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
    {
        var response = await _authenticationRepo.Login(model);
        return Ok(response);
    }
}