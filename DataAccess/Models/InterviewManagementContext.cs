using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class InterviewManagementContext : DbContext
{
    public InterviewManagementContext()
    {
    }

    public InterviewManagementContext(DbContextOptions<InterviewManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<CandidateSkill> CandidateSkills { get; set; }

    public virtual DbSet<CandidateStatus> CandidateStatuses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<InterviewerSchedule> InterviewerSchedules { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobSkill> JobSkills { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-ILAJU5E\\HUY;Database=InterviewManagement;TrustServerCertificate=True;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC07193A6F0B");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Cvattachment)
                .HasColumnType("ntext")
                .HasColumnName("CVAttachment");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Gender).HasMaxLength(100);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Recruiter).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.RecruiterId)
                .HasConstraintName("FK__Candidate__Recru__36B12243");

            entity.HasOne(d => d.Status).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Candidate__Statu__35BCFE0A");
        });

        modelBuilder.Entity<CandidateSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC078B72FF3B");

            entity.ToTable("CandidateSkill");

            entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateSkills)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidate__Candi__398D8EEE");

            entity.HasOne(d => d.Skill).WithMany(p => p.CandidateSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidate__Skill__3A81B327");
        });

        modelBuilder.Entity<CandidateStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC0723EAB85E");

            entity.ToTable("CandidateStatus");

            entity.Property(e => e.StatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07CA3A503B");

            entity.Property(e => e.DepartmentName).HasMaxLength(200);
        });

        modelBuilder.Entity<InterviewerSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3214EC07F3C79308");

            entity.ToTable("InterviewerSchedule");

            entity.Property(e => e.Note).HasColumnType("ntext");

            entity.HasOne(d => d.Interview).WithMany(p => p.InterviewerSchedules)
                .HasForeignKey(d => d.InterviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Inter__3F466844");

            entity.HasOne(d => d.Shedule).WithMany(p => p.InterviewerSchedules)
                .HasForeignKey(d => d.SheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Shedu__403A8C7D");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jobs__3214EC07E4A654A8");

            entity.Property(e => e.Benefits).HasColumnType("ntext");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.SalaryFrom).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalaryTo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<JobSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobSkill__3214EC075029025A");

            entity.ToTable("JobSkill");

            entity.HasOne(d => d.Job).WithMany(p => p.JobSkills)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobSkill__JobId__300424B4");

            entity.HasOne(d => d.Skill).WithMany(p => p.JobSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobSkill__SkillI__30F848ED");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Offers__3214EC073B7C222F");

            entity.Property(e => e.BaseSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ContractType).HasMaxLength(100);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.OfferStatus).HasMaxLength(100);

            entity.HasOne(d => d.ApprovedByManager).WithMany(p => p.Offers)
                .HasForeignKey(d => d.ApprovedByManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offers__Approved__45F365D3");

            entity.HasOne(d => d.Department).WithMany(p => p.Offers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offers__Departme__44FF419A");

            entity.HasOne(d => d.Position).WithMany(p => p.Offers)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offers__Position__46E78A0C");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC07D6944344");

            entity.Property(e => e.PositionName).HasMaxLength(200);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0788086A30");

            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC07646F1A23");

            entity.Property(e => e.InterviewTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.InterviewTimeStart).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.MeetingId).HasMaxLength(200);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.Result).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07AAF5A10E");

            entity.Property(e => e.SkillName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F7063020");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Status).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__Departmen__29572725");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
