using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPFTechnoservice.Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArdwareComponent> ArdwareComponents { get; set; }

    public virtual DbSet<ClientOrderComment> ClientOrderComments { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<EquipmentSparePartsOrder> EquipmentSparePartsOrders { get; set; }

    public virtual DbSet<EquipmentSparePartsOrderOrderClient> EquipmentSparePartsOrderOrderClients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrderedSparePart> OrderedSpareParts { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<QualitiesWorkPerformed> QualitiesWorkPerformeds { get; set; }

    public virtual DbSet<ReplacementEquipmentPart> ReplacementEquipmentParts { get; set; }

    public virtual DbSet<ReportWorksDone> ReportWorksDones { get; set; }

    public virtual DbSet<StagesExecution> StagesExecutions { get; set; }

    public virtual DbSet<TypesEquipment> TypesEquipments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WorkApplicationEquipment> WorkApplicationEquipments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=169.254.131.3;Initial Catalog=!!!!de_2024_Gulidov;User ID=stud;Password=Qwerty123456$;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArdwareComponent>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<ClientOrderComment>(entity =>
        {
            entity.HasOne(d => d.ClientOrder).WithMany(p => p.ClientOrderComments)
                .HasForeignKey(d => d.ClientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientOrderComments_Orders");

            entity.HasOne(d => d.Executor).WithMany(p => p.ClientOrderComments)
                .HasForeignKey(d => d.ExecutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientOrderComments_Users");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.SerialNumber).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.TypeEquipment).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.TypeEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Equipments_TypesEquipment");
        });

        modelBuilder.Entity<EquipmentSparePartsOrder>(entity =>
        {
            entity.Property(e => e.DateCreted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<EquipmentSparePartsOrderOrderClient>(entity =>
        {
            entity.ToTable("EquipmentSparePartsOrderOrderClient");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ClientOrder).WithMany(p => p.EquipmentSparePartsOrderOrderClients)
                .HasForeignKey(d => d.ClientOrderId)
                .HasConstraintName("FK_EquipmentSparePartsOrderOrderClient_Orders");

            entity.HasOne(d => d.EquipmentSparePartsOrder).WithMany(p => p.EquipmentSparePartsOrderOrderClients)
                .HasForeignKey(d => d.EquipmentSparePartsOrderId)
                .HasConstraintName("FK_EquipmentSparePartsOrderOrderClient_EquipmentSparePartsOrders");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.DateCreted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDateOfWork).HasColumnType("datetime");
            entity.Property(e => e.EndProcessingTime).HasColumnType("datetime");
            entity.Property(e => e.TypeMalfunction).HasMaxLength(255);

            entity.HasOne(d => d.Client).WithMany(p => p.OrderClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Equipments");

            entity.HasOne(d => d.Executor).WithMany(p => p.OrderExecutors)
                .HasForeignKey(d => d.ExecutorId)
                .HasConstraintName("FK_Orders_Users1");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderStatuses");

            entity.HasOne(d => d.Priority).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK_Orders_Priorities");

            entity.HasOne(d => d.QualityWorkPerformed).WithMany(p => p.Orders)
                .HasForeignKey(d => d.QualityWorkPerformedId)
                .HasConstraintName("FK_Orders_QualitiesWorkPerformed");

            entity.HasOne(d => d.StageExecution).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StageExecutionId)
                .HasConstraintName("FK_Orders_StagesExecution");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<OrderedSparePart>(entity =>
        {
            entity.ToTable("OrderedSparePart");

            entity.HasOne(d => d.EquipmentSparePartsOrder).WithMany(p => p.OrderedSpareParts)
                .HasForeignKey(d => d.EquipmentSparePartsOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedSparePart_EquipmentSparePartsOrders");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<QualitiesWorkPerformed>(entity =>
        {
            entity.ToTable("QualitiesWorkPerformed");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<ReplacementEquipmentPart>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.ArdwareComponentNewNavigation).WithMany(p => p.ReplacementEquipmentPartArdwareComponentNewNavigations)
                .HasForeignKey(d => d.ArdwareComponentNew)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReplacementEquipmentParts_ArdwareComponents1");

            entity.HasOne(d => d.ArdwareComponentOldNavigation).WithMany(p => p.ReplacementEquipmentPartArdwareComponentOldNavigations)
                .HasForeignKey(d => d.ArdwareComponentOld)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReplacementEquipmentParts_ArdwareComponents");

            entity.HasOne(d => d.ClientOrder).WithMany(p => p.ReplacementEquipmentParts)
                .HasForeignKey(d => d.ClientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReplacementEquipmentParts_Orders");
        });

        modelBuilder.Entity<ReportWorksDone>(entity =>
        {
            entity.ToTable("ReportWorksDone");

            entity.HasOne(d => d.WorkApplicationEquipment).WithMany(p => p.ReportWorksDones)
                .HasForeignKey(d => d.WorkApplicationEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportWorksDone_WorkApplicationEquipment");
        });

        modelBuilder.Entity<StagesExecution>(entity =>
        {
            entity.ToTable("StagesExecution");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TypesEquipment>(entity =>
        {
            entity.ToTable("TypesEquipment");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserRoles");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<WorkApplicationEquipment>(entity =>
        {
            entity.ToTable("WorkApplicationEquipment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TimeEndWork).HasColumnType("datetime");
            entity.Property(e => e.TimeStartWork)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ClientOrder).WithMany(p => p.WorkApplicationEquipments)
                .HasForeignKey(d => d.ClientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkApplicationEquipment_Orders");

            entity.HasOne(d => d.Executor).WithMany(p => p.WorkApplicationEquipments)
                .HasForeignKey(d => d.ExecutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkApplicationEquipment_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
