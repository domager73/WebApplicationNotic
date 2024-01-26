using WebApplicationNotic.Dto;
using WebApplicationNotic.Exceptions;
using WebApplicationNotic.Reposiroties;

namespace WebApplicationNotic.Services;

public class GroupsService
{
    private GroupsRepositories _groupsRepositories;
    private UserRepositories _userRepositories;

    public GroupsService(GroupsRepositories groupsRepositories, UserRepositories userRepositories)
    {
        _groupsRepositories = groupsRepositories;
        _userRepositories = userRepositories;
    }

    public void CreateGroup(RequestGroupDto requestGroupDto)
    {
        _groupsRepositories.CreateGroup(requestGroupDto);
    }
    
    public void InvitedToGroup(RequestInviteDto requestInviteDto)
    {
        if (_userRepositories.GetUserById(requestInviteDto.UserId) == null)
        {
            throw new UserException("Invite exeption", $"user with {requestInviteDto.UserId} does not exist", 401);
        }
        
        if (_groupsRepositories.GetGroupById(requestInviteDto.GroupId) == null)
        {
            throw new UserException("Invite exeption", $"group with {requestInviteDto.GroupId} does not exist", 402);
        }

        _groupsRepositories.InvitedToGroup(requestInviteDto);
    }
}