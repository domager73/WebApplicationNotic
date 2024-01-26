using System;
using System.Collections.Generic;

namespace WebApplicationTicketsCRUD.Db.Models;

public partial class Color
{
    public int Id { get; set; }

    public string ColorHex { get; set; } = null!;
}
