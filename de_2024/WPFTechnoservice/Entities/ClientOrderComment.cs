using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class ClientOrderComment
{
    public int Id { get; set; }

    public int ClientOrderId { get; set; }

    public int ExecutorId { get; set; }

    public string CommentText { get; set; } = null!;

    public virtual Order ClientOrder { get; set; } = null!;

    public virtual User Executor { get; set; } = null!;
}
