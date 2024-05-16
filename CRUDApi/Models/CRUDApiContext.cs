using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDApi.Models
{
    public partial class CRUDApiContext : DbContext
    {
        public CRUDApiContext()
        {
        }

        public CRUDApiContext(DbContextOptions<CRUDApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.RollNo)
                    .HasName("PK__Students__7886D5A0AD70C10B");

                entity.Property(e => e.RollNo).ValueGeneratedNever();

                entity.Property(e => e.FatherName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Father Name");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Standard)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
