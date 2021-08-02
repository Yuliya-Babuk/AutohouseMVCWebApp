using AppAutohouse.BLL;
using AppAutohouse.DAL.Context;
using AppAutohouse.PL.Mappers;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using MVCAppAutohouse.DAL.Repositories;

namespace AppAutohouse.PL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AutohouseContext>(options => options.UseInMemoryDatabase("FakeDb"));
            services.AddScoped<IRepository<Car>, CarRepository>();
            services.AddScoped<IService<Car>, CarService>();
            services.AddScoped<IRepository<Brand>, BrandRepository>();
            services.AddScoped<IService<Brand>, BrandService>();



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
