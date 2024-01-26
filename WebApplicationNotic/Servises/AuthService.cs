using System.IdentityModel.Tokens.Jwt;
using WebApplicationNotic.Dto;
using WebApplicationNotic.Exceptions;
using WebApplicationNotic.Reposiroties;
using WebApplicationNotic.Utils;

namespace WebApplicationNotic.Services;

public class AuthService
{
    private UserRepositories _userRepositories;
    private readonly IConfiguration _configuration;

    public AuthService(UserRepositories userRepositories, IConfiguration configuration)
    {
        _userRepositories = userRepositories;
        _configuration = configuration;
    }

    public string SingIn(RequestUserDto requestUserDto)
    {
        var realUser = _userRepositories.GetUserByEmail(requestUserDto);
        
        if (realUser == null)
        {
            throw new UserException("SingIn Exception", $"email does not exist", 401);
        }
        
        if (realUser.Password != requestUserDto.Password)
        {
            throw new UserException("SingIn Exception", $"email with password: {requestUserDto.Password} does not exist", 402);
        }

        JwtSecurityToken token = JwtUtils.CreateNewJwtToken(requestUserDto.Email, _configuration);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public string SingUp(RequestUserDto requestUserDto)
    {
        var user = _userRepositories.GetUserByEmail(requestUserDto);
        
        if (user != null)
        {
            throw new UserException("SingUp Exception", $"email already exist ", 401);
        }
        
        _userRepositories.CreateUser(requestUserDto);

        JwtSecurityToken token = JwtUtils.CreateNewJwtToken(requestUserDto.Email, _configuration);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}