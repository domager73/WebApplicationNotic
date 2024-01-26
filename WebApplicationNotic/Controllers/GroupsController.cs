using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNotic.Dto;
using WebApplicationNotic.Services;

namespace WebApplicationNotic.Controllers;

[Authorize]
[ApiController]
[Route("groups/")]
public class GroupsController : ControllerBase
{
    private GroupsService _groupsService;

    public GroupsController(GroupsService groupsService)
    {
        _groupsService = groupsService;
    }

    [HttpPost("create")]
    public void CreateGroup(RequestGroupDto requestGroupDto)
    {
        _groupsService.CreateGroup(requestGroupDto);
    }
    
    [HttpPost("invite")]
    public void CreateGroup(RequestInviteDto requestInviteDto)
    {
        _groupsService.InvitedToGroup(requestInviteDto);
    }
}