using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class Priority
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int PriorityNumberType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
