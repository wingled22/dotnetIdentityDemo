using System;
using System.Collections.Generic;

namespace dotnetIdentityDemo.Entities;

public partial class Aspnetuserlogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public int UserId { get; set; }

    public virtual Aspnetuser User { get; set; } = null!;
}
