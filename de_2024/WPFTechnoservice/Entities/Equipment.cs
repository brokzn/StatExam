using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypeEquipmentId { get; set; }

    public Guid SerialNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual TypesEquipment TypeEquipment { get; set; } = null!;
}
