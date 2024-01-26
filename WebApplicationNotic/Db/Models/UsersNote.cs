using System;
using System.Collections.Generic;

namespace WebApplicationNotic.Db.Models;

public partial class UsersNote
{
    public int UserId { get; set; }

    public int NoteId { get; set; }

    public virtual Note Note { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
