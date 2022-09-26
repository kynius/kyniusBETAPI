using System.Net;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationRepo _authenticationRepo;

    public AuthenticationController(IAuthenticationRepo authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _authenticationRepo.Register(model);
            return Ok(response);
        }
        return BadRequest(ModelState);
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _authenticationRepo.Login(model);
            return Ok(response);
        }
        return BadRequest(ModelState);
    }
}