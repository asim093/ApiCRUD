using System;
using System.Collections.Generic;

namespace FirstApi.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Player? Player { get; set; }
}
