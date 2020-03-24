using System;

namespace EfOdataTest.Entities
{
    public class WeatherForecast
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int TemperatureC { get; set; }

        public virtual string Summary { get; set; }
    }
}
