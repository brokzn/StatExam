using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class StagesExecution
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
