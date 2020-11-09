using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KAB_SQL_API.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SourceSystem> SourceSystem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SourceSystem>(entity =>
            {
                entity.ToTable("sourceSystem");

                entity.Property(e => e.Countryid)
                    .HasColumnName("COUNTRYID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.Erplegalentity)
                    .HasColumnName("ERPLEGALENTITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalErp)
                    .HasColumnName("LOCAL ERP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceDescription)
                    .HasColumnName("sourceDescription")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SourceSystem1)
                    .IsRequired()
                    .HasColumnName("sourceSystem")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SourceSystemId)
                    .HasColumnName("sourceSystemID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
