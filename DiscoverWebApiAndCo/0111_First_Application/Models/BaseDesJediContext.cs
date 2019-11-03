using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _0111_First_Application.Models
{
    public partial class BaseDesJediContext : DbContext
    {
        public BaseDesJediContext()
        {
        }

        public BaseDesJediContext(DbContextOptions<BaseDesJediContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Droide> Droide { get; set; }
        public virtual DbSet<DroideRoles> DroideRoles { get; set; }
        public virtual DbSet<EquipeCombat> EquipeCombat { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LES1U0B\\SQLEXPRESS;Database=BaseDesJedi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Droide>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEquipeCombat).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdEquipeCombatNavigation)
                    .WithMany(p => p.Droide)
                    .HasForeignKey(d => d.IdEquipeCombat)
                    .HasConstraintName("FK_Droide_EquipeCombat");
            });

            modelBuilder.Entity<DroideRoles>(entity =>
            {
                entity.HasKey(e => new { e.DroideId, e.RoleId });

                entity.Property(e => e.DroideId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RoleId).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<EquipeCombat>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
