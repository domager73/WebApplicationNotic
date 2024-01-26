using System;
using System.Collections.Generic;

namespace WebApplicationNotic.Db.Models;

public partial class Note
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Description { get; set; } = null!;

    public int ImportanciaId { get; set; }

    public int NoteTypeId { get; set; }

    public virtual ImportanciaLevel Importancia { get; set; } = null!;

    public virtual NoteType NoteType { get; set; } = null!;
}
