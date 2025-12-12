using System;
using System.Collections.Generic;

namespace EtteremApi13A.Models;

public partial class Rendele
{
    public int RendelesId { get; set; }

    public int AsztalSzam { get; set; }

    public string FizetesMod { get; set; } = null!;

    public virtual ICollection<Rendelestetel> Rendelestetels { get; set; } = new List<Rendelestetel>();
}
