using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirst.DatabaseEntity
{
    public partial class empdetailsContext : DbContext
    {
        public empdetailsContext()
        {
        }

        public empdetailsContext(DbContextOptions<empdetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Empdetail> Empdetails { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<TblDoctor> TblDoctors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET800;Initial Catalog=empdetails;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(x=>x.Depid);

                entity.ToTable("department");

                entity.Property(e => e.DepName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany()
                    .HasForeignKey(d => d.Depid)
                    .HasConstraintName("FK__departmen__Depid__2C3393D0");
            });

            modelBuilder.Entity<Empdetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("empdetail");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Student__DB9CAA5F45B61D91");

                entity.ToTable("Student");

                entity.Property(e => e.DepId).ValueGeneratedNever();

                entity.Property(e => e.StudName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("studName");
            });

            modelBuilder.Entity<TblDoctor>(entity =>
            {
                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
