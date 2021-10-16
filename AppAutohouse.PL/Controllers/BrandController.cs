using AppAutohouse.BLL;
using AppAutohouse.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppAutohouse.PL
{
    public class BrandController : Controller

    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;       

        public BrandController(IBrandService brandService, ICarService carService)
        {
            _carService = carService;
            _brandService = brandService;            
        }

        [Route("brands")]
        public IActionResult Brands()
        {
            return View(_brandService.GetAll()); //передаем браузеру
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteBrandAsync(int id)
        {
            await _brandService.DeleteAsync(id);
            return RedirectToAction("Brands");
        }

        public IActionResult GetInfoById(int id)
        {
            var cars = _carService.GetAllByBrandId(id);
            return View(cars);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateOrCreateAsync(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var res =await _brandService.GetByIdAsync(brand.Id);
                if (res is not null)
                {
                    await _brandService.UpdateAsync(brand);
                }
                else
                {
                    await _brandService.AddNewAsync(brand);
                }
                return RedirectToAction("Brands");
            }

            return View("UpdateOrCreate", brand);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateOrCreateAsync(int id)
        {
            var brand =await _brandService.GetByIdAsync(id);
            if (brand is not null)
            {
                return View("UpdateOrCreate", brand);
            }
            return View("UpdateOrCreate", new Brand());
        }

    }
}
