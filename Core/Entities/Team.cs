using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Team
{
    public int Id { get; set; }
    public string Name { get; set; }

    //public virtual ICollection<Driver> IdDrivers { get; set; } = new List<Driver>();
    public ICollection<Driver> Drivers { get; set; } = new HashSet<Driver>();
    public ICollection<TeamDriver> TeamDrivers { get; set; }
}
