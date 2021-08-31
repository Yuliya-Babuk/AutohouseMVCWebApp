using AppAutohouse.BLL;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppAutohouse.PL
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller

    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;
        public CatalogController(IBrandService brandService, ICarService carService)
        {
            _brandService = brandService;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            try
            {
                return Ok(_carService.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e?.Message);
                Log.Error(e?.InnerException?.Message);
                ModelState.AddModelError("key", "Something goes wrong");
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetInfoById(int id)
        {
            try
            {
                return Ok(_carService.GetById(id));
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
