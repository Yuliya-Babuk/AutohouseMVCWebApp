using AppAutohouse.BLL;
using AppAutohouse.PL.Mappers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppAutohouse.PL
{
    public class BrandController : Controller

    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, ICarService carService, IMapper mapper)
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DeleteBrand(int id)
        {
            _brandService.Delete(id);
            return RedirectToAction("Brands");
        }

        public IActionResult GetInfoById(int id)
        {
            var cars = _carService.GetAll().Where(x=>x.BrandId ==id);
            return View(cars);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult UpdateOrCreate(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var res = _brandService.GetAll().FirstOrDefault(c => c.Id == brand.Id);
                if (res is not null)
                {
                    _brandService.Update(brand);
                }
                else
                {
                    _brandService.AddNew(brand);
                }
                return RedirectToAction("Brands");
            }

            return View("UpdateOrCreate", brand);
        }

        [Authorize(Roles = "admin")]
        public IActionResult UpdateOrCreate(int id)
        {
            var brand = _brandService.GetAll().FirstOrDefault(c => c.Id == id);
            if (brand is not null)
            {
                return View("UpdateOrCreate", brand);
            }
            return View("UpdateOrCreate", new Brand());
        }

    }
}
