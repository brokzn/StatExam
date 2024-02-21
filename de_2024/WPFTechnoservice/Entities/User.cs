using System;
using System.Collections.Generic;

namespace WPFTechnoservice.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserRoleId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<ClientOrderComment> ClientOrderComments { get; set; } = new List<ClientOrderComment>();

    public virtual ICollection<Order> OrderClients { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderExecutors { get; set; } = new List<Order>();

    public virtual UserRole UserRole { get; set; } = null!;

    public virtual ICollection<WorkApplicationEquipment> WorkApplicationEquipments { get; set; } = new List<WorkApplicationEquipment>();
}
