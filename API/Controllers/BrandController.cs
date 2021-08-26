using AppAutohouse.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
            

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
           
        }

        [HttpGet("brands")]
        public IActionResult Brands()
        {
            return Ok(_brandService.GetAll());
        }
    }
}
