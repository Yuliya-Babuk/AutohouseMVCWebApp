using AppAutohouse.BLL;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("Brands")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;

        }

        [HttpGet]
        public IActionResult Brands()
        {
            try
            {
                return Ok(_brandService.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e?.Message);
                Log.Error(e?.InnerException?.Message);
                ModelState.AddModelError("key", "Something goes wrong");
                return BadRequest();

            }
        }
    }
}
