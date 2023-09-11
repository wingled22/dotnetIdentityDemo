﻿using System;
using System.Collections.Generic;

namespace dotnetIdentityDemo.Entities;

public partial class Aspnetuser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Firstname { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Contact { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? UserType { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<Aspnetuserclaim> Aspnetuserclaims { get; } = new List<Aspnetuserclaim>();

    public virtual ICollection<Aspnetuserlogin> Aspnetuserlogins { get; } = new List<Aspnetuserlogin>();

    public virtual ICollection<Aspnetusertoken> Aspnetusertokens { get; } = new List<Aspnetusertoken>();

    public virtual ICollection<Aspnetrole> Roles { get; } = new List<Aspnetrole>();
}
