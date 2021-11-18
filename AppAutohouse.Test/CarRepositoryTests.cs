using AppAutohouse.DAL.Context;
using AppAutohouse.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAutohouse.BLL.Test
{
    public class CarRepositoryTests
    {
        readonly DbContextOptions<AutohouseContext> options = new DbContextOptionsBuilder<AutohouseContext>()
        .UseInMemoryDatabase(databaseName: "DataBase")
        .Options;

        [SetUp]
        public void Setup()
        {

        }

        [TestCase("audi")]
        [TestCase("3.2")]
        [TestCase("X6")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task SearchTest(string testWord)
        {
            using var context = new AutohouseContext(options);
            //Arrange

            List<Brand> brands = new List<Brand>()
            {
                new Brand() {Id = 1, Name = "Audi", Description = "Audi is the most prominent car brand for designing the best car interiors, with easy and accessible controls. Its MMI infotainment system is among the best available amongst the other brands. This car brand has the biggest vehicle line ups from being super-mini to being supra huge with the best available diesel and hybrid engines making it prominent for road racing."
                , Logo = "https://cdn.freelogovectors.net/wp-content/uploads/2016/12/audi-logo.png" },
                new Brand() {Id = 2, Name = "BMW", Description = "With a wide range of innovative vehicle model, this car brand is known for its reliability and luxury status. This automobile company has serves its customers with luxurious piloting on the roads, while making sure that comfort has been served, from its passenger vehicles to its SUV, it will always be a great ride."
                , Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/BMW.svg/2048px-BMW.svg.png" },
                new Brand() {Id = 3, Name = "Volkswagen", Description = "This car brand is attentive enough with it comes to detailing of their model, each model is well detailed with the best technological features as well as well-equipped model design. This car brand is the most stylish and comfortable amongst the other car brands in terms of its design and affordability with a favourable service cost."
                , Logo = "https://cdn.motor1.com/images/mgl/pqj8V/s3/logo-story-volkswagen.webp" }
            };

            List<Car> cars = new List<Car>()
            {
                new Car() { Id = 1, Model = "A6", BrandId = brands[0].Id, EngineType = EngineType.Petrol,
                    EngineSize = 2.2, Year = 2008, Price = 8500, Photo = null },
                new Car() { Id = 2, Model = "A8", BrandId = brands[0].Id, EngineType = EngineType.Diesel,
                    EngineSize = 2.5, Year = 2010, Price = 13500, Photo = null },
                new Car() { Id = 3, Model = "X6", BrandId = brands[1].Id, EngineType = EngineType.Diesel,
                    EngineSize = 3.2, Year = 2020, Price = 20500, Photo = null }
            };

            var repository = new CarRepository(context);

            await context.Cars.AddRangeAsync(cars);
            await context.Brands.AddRangeAsync(brands);
            await context.SaveChangesAsync();

            //Act
            var actual = (await repository.SearchAsync(testWord, 1, cars.Count())).Item2;

            var expected = string.IsNullOrEmpty(testWord) || string.IsNullOrWhiteSpace(testWord)
                 ? await context.Cars.CountAsync()
                 : await context.Cars.Include(x => x.Brand).CountAsync(x => x.Model.Contains(testWord) || x.Brand.Name.Contains(testWord)
                   || x.EngineSize.ToString().Contains(testWord));

            //Assert
            Assert.AreEqual(expected, actual);
            await context.Database.EnsureDeletedAsync();
        }

    }

}