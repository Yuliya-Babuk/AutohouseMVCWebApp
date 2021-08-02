using AppAutohouse.BLL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using System.Linq;

namespace AppAutohouse.PL
{
    public class BrandController : Controller

    {
        private readonly IService<Brand> _brandService;
        private readonly IService<Car> _carService;
        private readonly IMapper _mapper;

        public BrandController(IService<Brand> brandService, IService<Car> carService, IMapper mapper)
        {
            _carService = carService;
            _brandService = brandService;
            _mapper = mapper;
        }

        [Route("[controller]")]
        public IActionResult Brands()
        {
            return View(_brandService.GetAll()); //передаем браузеру
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(Brand newBrand) //получаем от браузера
        {
            _brandService.AddNew(newBrand);
            return RedirectToAction("Brands");
        }

        [HttpPost]
        public IActionResult DeleteBrand(int Id)
        {
            _brandService.Delete(Id);
            return RedirectToAction("Brands");
        }

        public IActionResult GetInfoById(int Id)
        {
            var cars = _carService.GetAll().Where(c => c.BrandId == Id);
            return View(cars);
        }

        [HttpPost]
        public IActionResult Update(Brand brand)
        {
            _brandService.Update(brand);
            return RedirectToAction("Brands");
        }
        public IActionResult Update(int Id)
        {
            return View(_brandService.GetAll().FirstOrDefault(c => c.Id == Id));
        }

    }
}
