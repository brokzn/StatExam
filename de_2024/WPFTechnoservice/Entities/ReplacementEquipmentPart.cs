using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class ReplacementEquipmentPart
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ArdwareComponentOld { get; set; }

    public int ArdwareComponentNew { get; set; }

    public int ClientOrderId { get; set; }

    public virtual ArdwareComponent ArdwareComponentNewNavigation { get; set; } = null!;

    public virtual ArdwareComponent ArdwareComponentOldNavigation { get; set; } = null!;

    public virtual Order ClientOrder { get; set; } = null!;
}
