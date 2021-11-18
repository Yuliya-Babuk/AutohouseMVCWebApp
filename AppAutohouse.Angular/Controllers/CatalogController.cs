using AppAutohouse.BLL;
using AppAutohouse.BLL.Services;
using AppAutohouse.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller

    {

        private readonly ICarService _carService;
        private const int itemsPerPage = 3;
         
        public CatalogController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Cars(int pageNumber = 1)
        {
            var (cars, itemsAmount) = _carService.GetAllForSale(pageNumber, itemsPerPage);
            (IEnumerable<Car> cars, int pagesAmount) result = (cars, PaginationService.PagesAmountCalculation(itemsAmount, itemsPerPage));
            return Ok(result);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] string searchLine, int pageNumber = 1)
        {
            var (cars, itemsAmount) = await _carService.SearchAsync(searchLine, pageNumber, itemsPerPage);
            (IEnumerable<Car> cars, int pagesAmount) result = (cars, PaginationService.PagesAmountCalculation(itemsAmount, itemsPerPage));
            return Ok(result);
        }

    }
}
