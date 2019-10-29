using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _0041_First_Application
{
    public partial class StarWarsDatabaseContext : DbContext
    {
        public StarWarsDatabaseContext()
        {
        }

        public StarWarsDatabaseContext(DbContextOptions<StarWarsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Padawann> Padawann { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LessonDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LessonLabel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PadawannId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Padawann)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.PadawannId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Padawann");
            });

            modelBuilder.Entity<Padawann>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlanetId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.Padawann)
                    .HasForeignKey(d => d.PlanetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Padawann_Planet");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
