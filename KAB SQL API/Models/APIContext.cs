using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KAB_SQL_API.Models;

namespace KAB_SQL_API.Models
{
    public partial class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C948B516D");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EOLAudit>(entity =>
            {
                entity.HasKey(e => e.EOLID)
                    .HasName("PK__EOLAudit__987196C83F38B4AC");

                entity.Property(e => e.SerialId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SuspBuild)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HeightRiserBuild)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TrimBuild)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SlideRailsBuild)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpperToSuspBuild)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ARestSBeltBuild)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TestPack)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<KAB_SQL_API.Models.EOLAudit> EOLAudit { get; set; }
    }
}
