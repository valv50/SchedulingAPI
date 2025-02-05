using Microsoft.EntityFrameworkCore;

namespace Scheduling.Infrastructure.Persistence
{
    public partial class SchedulingContext : DbContext
    {
        public SchedulingContext()
        {
        }

        public SchedulingContext(DbContextOptions<SchedulingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Domain.Models.Company> Companies { get; set; }

        public virtual DbSet<Domain.Models.CompanyType> CompanyTypes { get; set; }

        public virtual DbSet<Domain.Models.Market> Markets { get; set; }

        public virtual DbSet<Domain.Models.Notifications> Notifications { get; set; }

        public virtual DbSet<Domain.Models.Schedule> Schedules { get; set; }

        public virtual DbSet<Domain.Models.ScheduleDate> ScheduleDates { get; set; }

        public virtual DbSet<Domain.Models.ScheduleType> ScheduleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Company>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Company");

                entity.Property(e => e.CompanyId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Market).WithMany()
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Market");

                entity.HasOne(d => d.Type).WithMany()
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_CompanyType");
            });

            modelBuilder.Entity<Domain.Models.CompanyType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("CompanyType");

                entity.Property(e => e.TypeId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Domain.Models.Notifications>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Domain.Models.Notifications>().ToTable("Notifications", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<Domain.Models.Market>(entity =>
            {
                entity.ToTable("Market");

                entity.Property(e => e.MarketId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Domain.Models.Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Market).WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Market");
            });

            modelBuilder.Entity<Domain.Models.ScheduleDate>(entity =>
            {
                entity.ToTable("ScheduleDate");

                entity.Property(e => e.ScheduleDateId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleDates)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleDate_Schedule");
            });

            modelBuilder.Entity<Domain.Models.ScheduleType>(entity =>
            {
                entity.ToTable("ScheduleType");

                entity.HasIndex(e => new { e.ScheduleId, e.TypeId }, "IX_ScheduleType");

                entity.Property(e => e.ScheduleTypeId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleTypes)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleType_Schedule");

                entity.HasOne(d => d.Type).WithMany(p => p.ScheduleTypes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleType_CompanyType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
