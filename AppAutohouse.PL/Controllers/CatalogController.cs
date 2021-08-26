using AppAutohouse.BLL;
using AppAutohouse.PL.Mappers;
using AppAutohouse.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppAutohouse.PL
{
    
    public class CatalogController : Controller

    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CatalogController(IBrandService brandService, ICarService carService, IMapper mapper)
        {
            _brandService = brandService;
            _carService = carService;
            _mapper = mapper;
        }

        [Route("[controller]")]
        public IActionResult Cars()
        {
            return View(_mapper.Map<IEnumerable<CarModel>>(_carService.GetAll()));
            //передаем браузеру
        }
                
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DeleteCar(int id)
        {
            _carService.Delete(id);
            return RedirectToAction("Cars");
        }

        public IActionResult GetInfoById(int id)
        {
            var car = _carService.GetById(id);
           
            return View(car);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult UpdateOrCreate(Car car)
        {
            if (ModelState.IsValid)
            {
                var res = _carService.GetAll().FirstOrDefault(c => c.Id == car.Id);
                if (res is not null)
                {
                    _carService.Update(car);
                }
                else
                {
                    _carService.AddNew(car);
                }
                return RedirectToAction("Cars");
            }
           
            return View("UpdateOrCreate", car);
        }
        [Authorize(Roles = "admin")]
        public IActionResult UpdateOrCreate(int Id)
        {
            var car = _carService.GetAll().FirstOrDefault(c => c.Id == Id);
            if (car is not null)
            {
                return View("UpdateOrCreate", car);
            }
            return View("UpdateOrCreate", new Car());
        }

    }
}
