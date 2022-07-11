using Microsoft.EntityFrameworkCore;
using WeatherHistory.Server.Models;

namespace WeatherHistory.Server.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>(l =>
            {
                l.HasKey(e => e.IdLocation);
                l.Property(e => e.Name).IsRequired().HasMaxLength(128);
            });

            modelBuilder.Entity<Temperature>(t =>
            {
                t.HasKey(e => e.IdTemperature);
                t.Property(e => e.Temp).IsRequired();
                t.Property(e => e.FeelsLike).IsRequired();
                t.Property(e => e.Pressure).IsRequired();
                t.Property(e => e.Humidity).IsRequired();
                t.Property(e => e.TempMin).IsRequired();
                t.Property(e => e.TempMax).IsRequired();
                t.Property(e => e.WeatherName).IsRequired().HasMaxLength(128);
                t.Property(e => e.Date).IsRequired();

                t.HasOne(e => e.Location).WithMany(e => e.Temperatures).HasForeignKey(e => e.IdLocation);
            });

        }
    }
}
