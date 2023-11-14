using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class asistencia360Context : DbContext
    {
        public asistencia360Context()
        {
        }

        public asistencia360Context(DbContextOptions<asistencia360Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Faq> Faqs { get; set; } = null!;
        public virtual DbSet<HardDrive> HardDrives { get; set; } = null!;
        public virtual DbSet<InternalService> InternalServices { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<sp_TicketsStatus_Result> sp_TicketsStatus_Result { get; set; } = null!;
        public virtual DbSet<sp_OpenTicketsByTechnician_Result> sp_OpenTicketsByTechnician_Result { get; set; } = null!;
        public virtual DbSet<sp_TicketsByCustomer_Result> sp_TicketsByCustomer_Result { get; set; } = null!;
        public virtual DbSet<sp_TicketsByCompany_Result> sp_TicketsByCompany_Result { get; set; } = null!;
        public virtual DbSet<sp_TicketsByService_Result> sp_TicketsByService_Result { get; set; } = null!;
        public virtual DbSet<sp_ServicesByCompany_Result> sp_ServicesByCompany_Result { get; set; } = null!;
        public virtual DbSet<sp_TicketsByInternalService_Result> sp_TicketsByInternalService_Result { get; set; } = null!;
        public virtual DbSet<sp_TicketsByType_Result> sp_TicketsByType_Result { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=52.146.47.143;port=3306;user=asistencia360;password=5RNbcIskM45;database=asistencia360;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasIndex(e => e.TicketId, "ticket_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(400)
                    .HasColumnName("attachment");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Message)
                    .HasMaxLength(400)
                    .HasColumnName("message");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_ibfk_2");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(120)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.CompanyId, "company_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(120)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_ibfk_1");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("faq");

                entity.Property(e => e.FaqId).HasColumnName("faq_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Notes)
                    .HasMaxLength(360)
                    .HasColumnName("notes");

                entity.Property(e => e.Problem)
                    .HasMaxLength(360)
                    .HasColumnName("problem");

                entity.Property(e => e.Solution)
                    .HasMaxLength(360)
                    .HasColumnName("solution");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(360)
                    .HasColumnName("symptom");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<HardDrive>(entity =>
            {
                entity.ToTable("hard_drive");

                entity.HasIndex(e => e.InventoryId, "inventory_id");

                entity.Property(e => e.HardDriveId).HasColumnName("hard_drive_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Size)
                    .HasMaxLength(120)
                    .HasColumnName("size");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.HardDrives)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hard_drive_ibfk_1");
            });

            modelBuilder.Entity<InternalService>(entity =>
            {
                entity.ToTable("internal_service");

                entity.Property(e => e.InternalServiceId).HasColumnName("internal_service_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AssetNumber)
                    .HasMaxLength(10)
                    .HasColumnName("asset_number");

                entity.Property(e => e.Cpu)
                    .HasMaxLength(20)
                    .HasColumnName("cpu");

                entity.Property(e => e.CpuCore).HasColumnName("cpu_core");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(30)
                    .HasColumnName("ip_address");

                entity.Property(e => e.OperativeSystem)
                    .HasMaxLength(120)
                    .HasColumnName("operative_system");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(150)
                    .HasColumnName("purpose");

                entity.Property(e => e.Ram).HasColumnName("ram");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(10)
                    .HasColumnName("serial_number");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasMaxLength(60)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(120)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.HasIndex(e => e.AdminId, "admin_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.OlaClose).HasColumnName("ola_close");

                entity.Property(e => e.OlaOpen).HasColumnName("ola_open");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .HasColumnName("priority");

                entity.Property(e => e.ServiceSchedule)
                    .HasMaxLength(50)
                    .HasColumnName("service_schedule");

                entity.Property(e => e.SlaClose).HasColumnName("sla_close");

                entity.Property(e => e.SlaOpen).HasColumnName("sla_open");

                entity.Property(e => e.SupportSchedule)
                    .HasMaxLength(120)
                    .HasColumnName("support_schedule");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service_ibfk_1");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.FaqId, "faq_id");

                entity.HasIndex(e => e.InternalServiceId, "internal_service_id");

                entity.HasIndex(e => e.InventoryId, "inventory_id");

                entity.HasIndex(e => e.ServiceId, "service_id");

                entity.HasIndex(e => e.TechnicianId, "technician_id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(400)
                    .HasColumnName("attachment");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.FaqId).HasColumnName("faq_id");

                entity.Property(e => e.InternalServiceId).HasColumnName("internal_service_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Priority)
                    .HasMaxLength(120)
                    .HasColumnName("priority");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.SolutionTime).HasColumnName("solution_time");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(120)
                    .HasColumnName("status");

                entity.Property(e => e.TechnicianId).HasColumnName("technician_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(120)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(120)
                    .HasColumnName("type");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TicketCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ticket_ibfk_1");

                entity.HasOne(d => d.Faq)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FaqId)
                    .HasConstraintName("ticket_ibfk_6");

                entity.HasOne(d => d.InternalService)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.InternalServiceId)
                    .HasConstraintName("ticket_ibfk_4");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("ticket_ibfk_5");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("ticket_ibfk_3");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.TicketTechnicians)
                    .HasForeignKey(d => d.TechnicianId)
                    .HasConstraintName("ticket_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.DepartmentId, "department_id");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .HasColumnName("email");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(9)
                    .HasColumnName("id_number");

                entity.Property(e => e.LastName)
                    .HasMaxLength(120)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
