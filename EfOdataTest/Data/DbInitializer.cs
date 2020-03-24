using EfOdataTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfOdataTest.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.WeatherForecasts.Any())
            {
                return;   // DB has been seeded
            }

            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            var rng = new Random();

            var entities = Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            }).ToArray();

            context.WeatherForecasts.AddRange(entities);

            context.SaveChanges();
        }
    }
}
