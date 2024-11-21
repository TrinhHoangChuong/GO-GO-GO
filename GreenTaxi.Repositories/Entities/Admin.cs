using System;
using System.Collections.Generic;

namespace GreenTaxi.Repositories.Entities;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Name { get; set; } = null!;
}
