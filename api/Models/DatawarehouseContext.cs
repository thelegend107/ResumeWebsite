
#nullable disable
using Microsoft.EntityFrameworkCore;

namespace ResumeBuilderAPI.Models
{
    public partial class DatawarehouseContext : DbContext
    {
        public DatawarehouseContext(DbContextOptions<DatawarehouseContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<SubRegion> SubRegions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Capital).HasMaxLength(50);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Emoji).HasMaxLength(50);

                entity.Property(e => e.ISO2)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ISO3)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NativeName).HasMaxLength(100);

                entity.Property(e => e.PhoneCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tld)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("fk_Regions_Countries");

                entity.HasOne(d => d.SubRegion)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.SubRegionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_SubRegions_Countries");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("fk_Countries_States");
            });

            modelBuilder.Entity<SubRegion>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.SubRegions)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Regions_SubRegions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}