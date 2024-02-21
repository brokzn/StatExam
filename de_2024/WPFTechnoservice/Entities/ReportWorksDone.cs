using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class ReportWorksDone
{
    public int Id { get; set; }

    public int WorkApplicationEquipmentId { get; set; }

    public string CauseMalfunction { get; set; } = null!;

    public string AssistanceProvided { get; set; } = null!;

    public virtual WorkApplicationEquipment WorkApplicationEquipment { get; set; } = null!;
}
