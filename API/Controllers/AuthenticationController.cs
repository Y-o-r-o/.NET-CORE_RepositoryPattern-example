using BusinessLayer.BusinessServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AuthenticationController : BaseApiController
{

    private IUserServices _userServices;

    public AuthenticationController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser(string id)
    {
        return HandleResult(await _userServices.GetUserAsync(id));
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        return HandleResult(await _userServices.LoginAsync(email,password));
    }

    [AllowAnonymous]
    [HttpGet("RefreshToken")]
    public async Task<IActionResult> RefreshToken(string requestRefreshToken)
    {
        return HandleResult(await _userServices.RefreshTokenAsync(requestRefreshToken));
    }


}