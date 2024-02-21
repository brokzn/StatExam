using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class OrderedSparePart
{
    public int ArdwareComponentId { get; set; }

    public double Price { get; set; }

    public int Id { get; set; }

    public int EquipmentSparePartsOrderId { get; set; }

    public virtual EquipmentSparePartsOrder EquipmentSparePartsOrder { get; set; } = null!;
}
