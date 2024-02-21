using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class QualitiesWorkPerformed
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
