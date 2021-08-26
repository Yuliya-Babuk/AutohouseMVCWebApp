using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAutohouse.DAL.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Brand>().HasMany<Car>(x => x.Cars).WithOne(x => x.Brand);

            List<Brand> brands = new List<Brand>()
            {
                new Brand() {Id = 1, Name = "Audi", Description = "Audi is the most prominent car brand for designing the best car interiors, with easy and accessible controls. Its MMI infotainment system is among the best available amongst the other brands. This car brand has the biggest vehicle line ups from being super-mini to being supra huge with the best available diesel and hybrid engines making it prominent for road racing."
                , Logo = "/images/car_logo_audi.png" },
                new Brand() {Id = 2, Name = "BMW", Description = "With a wide range of innovative vehicle model, this car brand is known for its reliability and luxury status. This automobile company has serves its customers with luxurious piloting on the roads, while making sure that comfort has been served, from its passenger vehicles to its SUV, it will always be a great ride."
                , Logo = "/images/car_logo_bmw.png" },
                new Brand() {Id = 3, Name = "Volkswagen", Description = "This car brand is attentive enough with it comes to detailing of their model, each model is well detailed with the best technological features as well as well-equipped model design. This car brand is the most stylish and comfortable amongst the other car brands in terms of its design and affordability with a favourable service cost."
                , Logo = "/images/car_logo_vw.png" },
            };

            builder.Entity<Brand>().HasData(brands);

            List<Car> cars = new List<Car>()
        {
            new Car() { Id = 1, Model = "A6", BrandId = brands[0].Id, EngineType = EngineType.Petrol,
            EngineSize = 2.2, Year=2008, Price = 8500},
            new Car() { Id = 2, Model = "A8", BrandId = brands[0].Id, EngineType = EngineType.Diesel,
            EngineSize = 2.5, Year=2010, Price = 13500},
            new Car() { Id = 3, Model = "X6", BrandId = brands[1].Id, EngineType = EngineType.Diesel,
            EngineSize = 3.2, Year=2020, Price = 20500}
        };
            builder.Entity<Car>().HasData(cars);
           
        }
    }
}
