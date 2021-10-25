using AppAutohouse.BLL;
using AppAutohouse.DAL.Entities;
using AppAutohouse.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace AppAutohouse.PL
{
    [Authorize(Roles = "admin")]
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
            return View(_carService.GetAll());
            //передаем браузеру
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            await _carService.DeleteAsync(id);
            return RedirectToAction("Cars");
        }

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
            else ModelState.AddModelError("", "Something goes wrong");
            return View("UpdateOrCreate", _mapper.Map<Car>(carModel));
        }

        public async Task<IActionResult> UpdateOrCreateAsync(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car is not null)
            {
                return View("UpdateOrCreate", car);
            }
            return View("UpdateOrCreate", new Car());
        }

     

    }
}
