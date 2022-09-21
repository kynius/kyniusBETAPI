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
    public async Task<IActionResult> Register([FromBody] UserDTO model)
    {
        var response = await _authenticationRepo.Register(model);
        return Ok(response);
    }
}