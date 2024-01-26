using System;
using System.Collections.Generic;

namespace WebApplicationNotic.Db.Models;

public partial class ImportanciaLevel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ColorId { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
