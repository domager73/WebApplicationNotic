using WebApplicationNotic.Db.DbConnector;
using WebApplicationNotic.Dto;
using WebApplicationNotic.Db.Models;

namespace WebApplicationNotic.Reposiroties;

public class UserRepositories
{
    private NoticDbContext _dbContext;

    public UserRepositories(NoticDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateUser(RequestUserDto requestUserDto)
    {
        _dbContext.Users.Add(new User()
        {
            Email = requestUserDto.Email,
            Password = requestUserDto.Password,
        });

        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(RequestUserDto requestUserDto)
    {
        return _dbContext.Users.FirstOrDefault(item => item.Email == requestUserDto.Email);
    }
    
    public User? GetUserById(int id)
    {
        return _dbContext.Users.FirstOrDefault(item => item.Id == id);
    }
}