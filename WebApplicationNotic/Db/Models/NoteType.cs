using System;
using System.Collections.Generic;

namespace WebApplicationNotic.Db.Models;

public partial class NoteType
{
    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
