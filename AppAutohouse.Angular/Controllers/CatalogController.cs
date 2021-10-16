using AppAutohouse.BLL;
using Microsoft.AspNetCore.Mvc;

namespace AppAutohouse.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller

    {

        private readonly ICarService _carService;
        public CatalogController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(_carService.GetAll());
        }

        [HttpGet("Search")]
        public IActionResult Search(string searchLine)
        {
            return Ok(_carService.SearchAsync(searchLine));
        }

    }
}
