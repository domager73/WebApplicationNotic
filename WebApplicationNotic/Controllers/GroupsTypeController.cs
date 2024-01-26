using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNotic.Controllers;

[Authorize]
[ApiController]
[Route("groups/")]
public class GroupsTypeController
{
    
}