using AppAutohouse.BLL;
using AppAutohouse.DAL.Context;
using AppAutohouse.PL.Mappers;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using MVCAppAutohouse.DAL.Repositories;
using Serilog;
using System;
using System.Threading.Tasks;

namespace AppAutohouse.PL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews()
                .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);

            services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Car>());

            services.AddDbContext<AutohouseContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AutohouseDb;Trusted_Connection=True;"));

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<AutohouseContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IRepository<Car>, CarRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRepository<Brand>, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();

            Log.Logger = new LoggerConfiguration()
                     .WriteTo.Console()
                        .CreateLogger();



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });

            CreateRoles(serviceProvider).Wait();
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "admin", "customer", "manager" };

            foreach (var roleName in roles)
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByEmailAsync(Configuration["AdminUserEmail"]);
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "admin");
            }
        }

        //папка Areas, PartialLayout и подключить к Layout
    }
}
