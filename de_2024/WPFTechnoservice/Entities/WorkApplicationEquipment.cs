using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class WorkApplicationEquipment
{
    public int Id { get; set; }

    public DateTime TimeStartWork { get; set; }

    public DateTime TimeEndWork { get; set; }

    public int ExecutorId { get; set; }

    public int ClientOrderId { get; set; }

    public double CostWork { get; set; }

    public virtual Order ClientOrder { get; set; } = null!;

    public virtual User Executor { get; set; } = null!;

    public virtual ICollection<ReportWorksDone> ReportWorksDones { get; set; } = new List<ReportWorksDone>();
}
