using AutoMapper;
using EfOdataTest.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EfOdataTest.ViewModels
{
    [Serializable]
    public class WeatherForecastVm
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }

    public class WeatherForecastVmAutoMapperProfile : Profile
    {
        public WeatherForecastVmAutoMapperProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastVm>()
                .ForMember(d => d.TemperatureF, map => map.MapFrom(s => 32 + (int)(s.TemperatureC / 0.5556)));
        }
    }
}
