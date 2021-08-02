using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using System;
using System.Collections.Generic;

namespace AppAutohouse.DAL.Context
{
    public class AutohouseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public AutohouseContext(DbContextOptions<AutohouseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected AutohouseContext()
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Brand>().HasMany<Car>(x => x.Cars).WithOne(x => x.Brand);
            

            List<Brand> brands = new List<Brand>()
            {
                new Brand() {Id = 1, Name = "Audi", Description = "", Logo = "" },
                new Brand() {Id = 2, Name = "BMW", Description = "", Logo = "" },

            };

            builder.Entity<Brand>().HasData(brands);

            List<Car> cars = new List<Car>()
        {  
            new Car() { Id = 1, Model = "A6", BrandId = brands[0].Id, TypeEngine = "Petrol", 
            EngineSize = 2.2, Year=2008, Price = 8500},
            new Car() { Id = 2, Model = "A8", BrandId = brands[0].Id, TypeEngine = "Diesel",
            EngineSize = 2.5, Year=2010, Price = 13500},
            new Car() { Id = 3, Model = "X6", BrandId = brands[1].Id, TypeEngine = "Diesel",
            EngineSize = 3.2, Year=2020, Price = 20500}
        };
            builder.Entity<Car>().HasData(cars);

            base.OnModelCreating(builder);

        }


    }
}
