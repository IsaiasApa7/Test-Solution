using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test_Solution.Models.dbModels
{
    public partial class TestSolutionContext : IdentityDbContext<ApplicationUser, IdentityRole<int>,int>
    {
        public TestSolutionContext()
        {
        }

        public TestSolutionContext(DbContextOptions<TestSolutionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<InspectionType> InspectionTypes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<VInspectionSatisfactory> VInspectionSatisfactories { get; set; }
        public virtual DbSet<VInspectionUnsatisfactory> VInspectionUnsatisfactories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BuildingName).IsUnicode(false);
            });

            modelBuilder.Entity<Inspection>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.InspectionType)
                    .WithMany(p => p.Inspections)
                    .HasForeignKey(d => d.InspectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspectionsType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Inspections)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status");

                entity.HasOne(d => d.IdUserNavigation)
                     .WithMany(p => p.Users)
                     .HasForeignKey(d => d.UserId)
                     .HasConstraintName("FK_Users");

            });

            modelBuilder.Entity<InspectionType>(entity =>
            {
                entity.Property(e => e.TypeName).IsUnicode(false);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.InspectionTypes)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusName).IsUnicode(false);
            });

            modelBuilder.Entity<VInspectionSatisfactory>(entity =>
            {
                entity.ToView("V_INSPECTION_SATISFACTORY");

                entity.Property(e => e.BuildingName).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.StatusName).IsUnicode(false);

                entity.Property(e => e.TypeName).IsUnicode(false);
            });

            modelBuilder.Entity<VInspectionUnsatisfactory>(entity =>
            {
                entity.ToView("V_INSPECTION_UNSATISFACTORY");

                entity.Property(e => e.BuildingName).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.StatusName).IsUnicode(false);

                entity.Property(e => e.TypeName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
