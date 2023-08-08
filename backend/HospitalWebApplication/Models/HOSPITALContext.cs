using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospitalWebApplication.Models
{
    public partial class HOSPITALContext : DbContext
    {
        public HOSPITALContext()
        {
        }

        public HOSPITALContext(DbContextOptions<HOSPITALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appontment> Appontments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Hospital> Hospitals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("HospitalDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appontment>(entity =>
            {
                entity.ToTable("APPONTMENTS");

                entity.Property(e => e.Appontmentid)
                    .ValueGeneratedNever()
                    .HasColumnName("APPONTMENTID");

                entity.Property(e => e.Appointmenttime)
                    .HasColumnType("datetime")
                    .HasColumnName("APPOINTMENTTIME");

                entity.Property(e => e.Doctorid).HasColumnName("DOCTORID");

                entity.Property(e => e.Hospitalid).HasColumnName("HOSPITALID");

                entity.Property(e => e.Userid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appontments)
                    .HasForeignKey(d => d.Doctorid)
                    .HasConstraintName("FK_DOCTORID");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Appontments)
                    .HasForeignKey(d => d.Hospitalid)
                    .HasConstraintName("FK_HOSPITALID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appontments)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERID");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK_DID");

                entity.ToTable("DOCTORS");

                entity.Property(e => e.Did)
                    .ValueGeneratedNever()
                    .HasColumnName("DID");

                entity.Property(e => e.Degree)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE");

                entity.Property(e => e.Dimage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIMAGE")
                    .HasDefaultValueSql("('../../../')");

                entity.Property(e => e.Dname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DNAME");

                entity.Property(e => e.Experience)
                    .HasColumnName("EXPERIENCE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Worksin).HasColumnName("WORKSIN");

                entity.HasOne(d => d.WorksinNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Worksin)
                    .HasConstraintName("FK_WORKSIN");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("HOSPITAL");

                entity.Property(e => e.Hospitalid)
                    .ValueGeneratedNever()
                    .HasColumnName("HOSPITALID");

                entity.Property(e => e.Contact).HasColumnName("CONTACT");

                entity.Property(e => e.Hospitaladdress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOSPITALADDRESS");

                entity.Property(e => e.Hospitalimage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOSPITALIMAGE")
                    .HasDefaultValueSql("('../../')");

                entity.Property(e => e.Hospitalname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOSPITALNAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Mailid)
                    .HasName("PK_MAIL");

                entity.ToTable("USERS");

                entity.Property(e => e.Mailid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MAILID");

                entity.Property(e => e.Contactumber).HasColumnName("CONTACTUMBER");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Pastproblems)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASTPROBLEMS");

                entity.Property(e => e.Useraddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERADDRESS");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
