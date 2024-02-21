using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class ArdwareComponent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ReplacementEquipmentPart> ReplacementEquipmentPartArdwareComponentNewNavigations { get; set; } = new List<ReplacementEquipmentPart>();

    public virtual ICollection<ReplacementEquipmentPart> ReplacementEquipmentPartArdwareComponentOldNavigations { get; set; } = new List<ReplacementEquipmentPart>();
}
