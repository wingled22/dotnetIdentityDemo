using System;
using System.Collections.Generic;

namespace dotnetIdentityDemo.Entities;

public partial class Aspnetrole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<Aspnetroleclaim> Aspnetroleclaims { get; } = new List<Aspnetroleclaim>();

    public virtual ICollection<Aspnetuser> Users { get; } = new List<Aspnetuser>();
}
