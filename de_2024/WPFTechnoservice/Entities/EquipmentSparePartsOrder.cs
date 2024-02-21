using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class EquipmentSparePartsOrder
{
    public int Id { get; set; }

    public DateTime DateCreted { get; set; }

    public virtual ICollection<EquipmentSparePartsOrderOrderClient> EquipmentSparePartsOrderOrderClients { get; set; } = new List<EquipmentSparePartsOrderOrderClient>();

    public virtual ICollection<OrderedSparePart> OrderedSpareParts { get; set; } = new List<OrderedSparePart>();
}
