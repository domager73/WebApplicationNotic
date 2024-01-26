using WebApplicationNotic.Db.DbConnector;
using WebApplicationNotic.Dto;
using WebApplicationNotic.Db.Models;

namespace WebApplicationNotic.Reposiroties;

public class GroupsRepositories
{
    private NoticDbContext _dbContext;

    public GroupsRepositories(NoticDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateGroup(RequestGroupDto requestGroupDto)
    {
        _dbContext.Groups.Add(new Group()
        {
            Name = requestGroupDto.Name
        });

        _dbContext.SaveChanges();
    }

    public void InvitedToGroup(RequestInviteDto requestInviteDto)
    {
        _dbContext.GroupsUsers.Add(new GroupsUser()
        {
            GroupId = requestInviteDto.GroupId,
            UserId = requestInviteDto.UserId
        });

        _dbContext.SaveChanges();
    }

    public Group? GetGroupById(int id)
    {
        return _dbContext.Groups.FirstOrDefault(group => group.Id == id);
    }
}