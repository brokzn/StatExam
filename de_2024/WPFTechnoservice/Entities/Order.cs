using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime DateCreted { get; set; }

    public int EquipmentId { get; set; }

    public string TypeMalfunction { get; set; } = null!;

    public string DescriptionProblems { get; set; } = null!;

    public int ClientId { get; set; }

    public int OrderStatusId { get; set; }

    public int? StageExecutionId { get; set; }

    public int? PriorityId { get; set; }

    public string? AdditionalInformation { get; set; }

    public int? ExecutorId { get; set; }

    public DateTime? EndProcessingTime { get; set; }

    public int? QualityWorkPerformedId { get; set; }

    public DateTime? EndDateOfWork { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual ICollection<ClientOrderComment> ClientOrderComments { get; set; } = new List<ClientOrderComment>();

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual ICollection<EquipmentSparePartsOrderOrderClient> EquipmentSparePartsOrderOrderClients { get; set; } = new List<EquipmentSparePartsOrderOrderClient>();

    public virtual User? Executor { get; set; }

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual Priority? Priority { get; set; }

    public virtual QualitiesWorkPerformed? QualityWorkPerformed { get; set; }

    public virtual ICollection<ReplacementEquipmentPart> ReplacementEquipmentParts { get; set; } = new List<ReplacementEquipmentPart>();

    public virtual StagesExecution? StageExecution { get; set; }

    public virtual ICollection<WorkApplicationEquipment> WorkApplicationEquipments { get; set; } = new List<WorkApplicationEquipment>();
}
