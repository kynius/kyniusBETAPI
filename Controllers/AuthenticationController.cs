using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace kyniusBETAPI.Controllers;
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _authenticationService.Register(model);
            return Ok(response);
        }
        return BadRequest(ModelState);
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _authenticationService.Login(model);
            return Ok(response);
        }
        return BadRequest(ModelState);
    }
}