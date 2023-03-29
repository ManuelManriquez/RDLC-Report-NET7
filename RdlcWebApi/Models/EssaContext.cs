using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RdlcWebApi.Models;

public partial class EssaContext : DbContext
{
    public EssaContext()
    {
    }

    public EssaContext(DbContextOptions<EssaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<ServicioSocialLetter> ServicioSocialLetters { get; set; }

    public virtual DbSet<ServicioSocialProcedure> ServicioSocialProcedures { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserLoginDatum> UserLoginData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ESSA;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("career_id");

            entity.ToTable("career");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CareerCurriculum)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("career_curriculum");
            entity.Property(e => e.CareerKey)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("career_key");
            entity.Property(e => e.CarrerCurriculumAcronym)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("carrer_curriculum_acronym");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServicioSocialLetter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicio_social_letter_pk");

            entity.ToTable("servicio_social_letter");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddresseeName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("addressee_name");
            entity.Property(e => e.AddresseePosition)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("addressee_position");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.FilePath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("file_path");
            entity.Property(e => e.HeadOfDepartmentName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("head_of_department_name");
            entity.Property(e => e.HeadOfDepartmentPosition)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("head_of_department_position");
            entity.Property(e => e.LetterType)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("letter_type");
            entity.Property(e => e.OfficialDependency)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("official_dependency");
            entity.Property(e => e.ProjectName)
                .IsUnicode(false)
                .HasColumnName("project_name");
            entity.Property(e => e.ScheduleDays)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("schedule_days");
            entity.Property(e => e.ScheduleEndHours).HasColumnName("schedule_end_hours");
            entity.Property(e => e.ScheduleStartHours).HasColumnName("schedule_start_hours");
            entity.Property(e => e.ServicioSocialProcedureId).HasColumnName("servicio_social_procedure_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StudentActivity)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("student_activity");
            entity.Property(e => e.StudentServiceModality)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("student_service_modality");
            entity.Property(e => e.SupervisorName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("supervisor_name");
            entity.Property(e => e.SupervisorPosition)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("supervisor_position");
            entity.Property(e => e.TotalHours).HasColumnName("total_hours");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ServicioSocialProcedure).WithMany(p => p.ServicioSocialLetters)
                .HasForeignKey(d => d.ServicioSocialProcedureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicio_social_servicio_social_procedure");

            entity.HasOne(d => d.Status).WithMany(p => p.ServicioSocialLetters)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicio_social_status");
        });

        modelBuilder.Entity<ServicioSocialProcedure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicio_social_procedure_pk");

            entity.ToTable("servicio_social_procedure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StudentControlNumber)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("student_control_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Status).WithMany(p => p.ServicioSocialProcedures)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("letter_status_servicio_social_procedure");

            entity.HasOne(d => d.StudentControlNumberNavigation).WithMany(p => p.ServicioSocialProcedures)
                .HasForeignKey(d => d.StudentControlNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicio_social_procedure_student");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_id");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.ControlNumber).HasName("control_number");

            entity.ToTable("student");

            entity.Property(e => e.ControlNumber)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("control_number");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("date")
                .HasColumnName("admission_date");
            entity.Property(e => e.CareerId).HasColumnName("career_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Nss)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nss");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.CareerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("students_career");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("students_user_account");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_account_pk");

            entity.ToTable("user_account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaternalName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("maternal_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.PaternalName)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("paternal_name");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UserLoginDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_id");

            entity.ToTable("user_login_data");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password_salt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.UserLoginData)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("user_login_data_user_account");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
