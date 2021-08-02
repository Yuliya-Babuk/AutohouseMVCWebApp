using AppAutohouse.BLL;
using AppAutohouse.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Repositories;
using System.Linq;

namespace AppAutohouse.PL
{
    public class CatalogController : Controller

    {
        private readonly IService<Car> _carService;
        private readonly IMapper _mapper;

        public CatalogController(IService<Car> carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [Route("[controller]")]
        public IActionResult Cars()
        {
            return View(_carService.GetAll()); //передаем браузеру
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car newCar) //получаем от браузера
        {
            var carModel = _mapper.Map<CarModel>(newCar);
            _carService.AddNew(newCar);
            return RedirectToAction("Cars");
        }

        [HttpPost]
        public IActionResult DeleteCar(int Id)
        {
            _carService.Delete(Id);
            return RedirectToAction("Cars");
        }

        public IActionResult GetInfoById(int Id)
        {
            var car = _carService.GetAll().FirstOrDefault(c => c.Id == Id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            _carService.Update(car);
            return RedirectToAction("Cars");
        }
        public IActionResult Update(int Id)
        {
            return View(_carService.GetAll().FirstOrDefault(c => c.Id == Id));
        }

    }
}
