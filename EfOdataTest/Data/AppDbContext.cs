using EfOdataTest.Entities;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EfOdataTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().ToTable("WeatherForecast");
        }
    }
}
