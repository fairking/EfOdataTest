using System.Linq;
using AutoMapper;
using EfOdataTest.Data;
using EfOdataTest.Entities;
using EfOdataTest.ViewModels;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;

namespace EfOdataTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddOData();
            services.AddODataQueryFilter();
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=efodatatest.db;"));
            services.AddAutoMapper((cfg) => { cfg.DisableConstructorMapping(); }, typeof(Program).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Expand().Select().Count().OrderBy().Filter().MaxTop(100);
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());
            });
        }

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<WeatherForecastVm>("WeatherForecast");
            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
