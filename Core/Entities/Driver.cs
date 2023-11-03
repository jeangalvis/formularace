﻿using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? Age { get; set; }

    // public virtual ICollection<Team> IdTeams { get; set; } = new List<Team>();
    public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    public ICollection<TeamDriver> TeamDrivers { get; set; }
}
