using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : BaseApiController
{

    private IAuthenticateService _authenticateService;

    public AuthenticationController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
    {
        return HandleResult(await _authenticateService.LoginAsync(loginDTO.Email,loginDTO.Password));
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromHeader(Name = "RefreshToken")] string refreshToken)
    {
        return HandleResult(await _authenticateService.RefreshTokenAsync(refreshToken));
    }

}