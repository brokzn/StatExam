using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class TypesEquipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
