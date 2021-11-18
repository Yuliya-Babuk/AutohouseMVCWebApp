using AppAutohouse.BLL;
using AppAutohouse.BLL.Services;
using AppAutohouse.DAL.Entities;
using AppAutohouse.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppAutohouse.PL
{
    [Authorize(Roles = "admin")]
    public class CarController : Controller

    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private const int itemsPerPage = 3;


        public CarController(IBrandService brandService, ICarService carService, IMapper mapper)
        {
            _brandService = brandService;
            _carService = carService;
            _mapper = mapper;
        }
        
        [Route("Cars/{pageNumber?}")]
        public IActionResult Cars(int pageNumber = 1)
        {
            ViewBag.CurrentPage = pageNumber;
            var (cars, itemsAmount) = _carService.GetAll(pageNumber, itemsPerPage);
            (IEnumerable<Car> cars, int pagesAmount) result = (cars, PaginationService.PagesAmountCalculation(itemsAmount, itemsPerPage));
            return View(result);
            //передаем браузеру
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            await _carService.DeleteAsync(id);
            return RedirectToAction("Cars");
        }

        [HttpGet]
        public async Task<IActionResult> GetInfoByIdAsync(int id)
        {            
            var car = await _carService.GetByIdAsync(id);
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrCreateAsync(CarModel carModel)
        {         

            if (ModelState.IsValid)
            {
                var car = _mapper.Map<Car>(carModel);

                if(carModel.Photo != null)
                {
                    await using var memoryStream = new MemoryStream();

                    await carModel.Photo.CopyToAsync(memoryStream);

                    var content = memoryStream.ToArray();

                    car.Photo = content;
                }              

                var res = await _carService.GetByIdAsync(car.Id);
             
                if (res is not null)
                {
                    if(car.Photo is null)
                    {
                        car.Photo = res.Photo;
                    }
                
                    await _carService.UpdateAsync(car);
                }
                else
                {
                    await _carService.AddNewAsync(car);
                }
                return RedirectToAction("Cars");
            }            
            return View("UpdateOrCreate", _mapper.Map<Car>(carModel));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrCreateAsync(int Id)
        {
            var car = await _carService.GetByIdAsync(Id);
            if (car is not null)
            {
                return View("UpdateOrCreate", car);
            }
            return View("UpdateOrCreate", new Car());
        }         

    }
}
