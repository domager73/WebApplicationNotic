using System;
using System.Collections.Generic;

namespace WebApplicationNotic.Db.Models;

public partial class GroupsUser
{
    public int UserId { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
