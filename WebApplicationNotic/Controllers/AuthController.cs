using Microsoft.AspNetCore.Mvc;
using WebApplicationNotic.Dto;
using WebApplicationNotic.Services;

namespace WebApplicationNotic.Controllers;

[Route("auth/")]
public class AuthController : ControllerBase
{
    private AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("sign-in")]
    public string SignIn(RequestUserDto requestUserDto)
    {
        return _authService.SingIn(requestUserDto);
    }
    
    [HttpPost("sign-up")]
    public string SignUp(RequestUserDto requestUserDto)
    {
        return _authService.SingUp(requestUserDto);
    }
}
