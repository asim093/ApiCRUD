using System;
using System.Collections.Generic;

namespace FirstApi.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int JersyNumber { get; set; }

    public string Skillls { get; set; } = null!;

    public virtual Team IdNavigation { get; set; } = null!;
}
