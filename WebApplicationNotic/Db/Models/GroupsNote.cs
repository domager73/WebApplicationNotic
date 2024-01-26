using System;
using System.Collections.Generic;

namespace WebApplicationNotic.Db.Models;

public partial class GroupsNote
{
    public int GroupId { get; set; }

    public int NoteId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Note Note { get; set; } = null!;
}
