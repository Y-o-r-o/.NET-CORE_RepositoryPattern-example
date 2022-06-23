using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AuthenticationController : BaseApiController
{

    private IAuthenticateService _authenticateService;

    public AuthenticationController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }


    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        return HandleResult(await _authenticateService.LoginAsync(loginDTO.Email,loginDTO.Password));
    }

    [AllowAnonymous]
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromHeader(Name = "RefreshToken")] string refreshToken)
    {
        return HandleResult(await _authenticateService.RefreshTokenAsync(refreshToken));
    }

}