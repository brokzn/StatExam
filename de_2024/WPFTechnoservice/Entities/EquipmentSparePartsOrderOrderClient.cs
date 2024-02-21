using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class EquipmentSparePartsOrderOrderClient
{
    public Guid Id { get; set; }

    public int? EquipmentSparePartsOrderId { get; set; }

    public int? ClientOrderId { get; set; }

    public virtual Order? ClientOrder { get; set; }

    public virtual EquipmentSparePartsOrder? EquipmentSparePartsOrder { get; set; }
}
