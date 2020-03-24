using AutoMapper;
using EfOdataTest.Data;
using EfOdataTest.ViewModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace EfOdataTest.Controllers
{
    [Route("/odata/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public WeatherForecastController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_mapper.ProjectTo<WeatherForecastVm>(_dbContext.WeatherForecasts));
            //return Ok(_mapper.ProjectTo<WeatherForecastVm>(_dbContext.WeatherForecasts.ToLinqToDB()));
            //return Ok(_dbContext.WeatherForecasts);
        }
    }
}
