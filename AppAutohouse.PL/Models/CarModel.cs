using AppAutohouse.DAL.Entities;
using AppAutohouse.PL.Mappers;
using Microsoft.AspNetCore.Http;
using MVCAppAutohouse.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppAutohouse.PL.Models
{
    public class CarModel
    {
        public int Id { get; set; }       
        public BrandModel Brand { get; set; }
        public int BrandId { get; set; }
        [Required]
        public string Model { get; set; }
        public EngineType EngineType { get; set; }
        [Required]
        public double? EngineSize { get; set; }
        [Required]
        [Range(2000, 2021)]
        public int? Year { get; set; }
        [Required]
        public int? Price { get; set; }
        public IFormFile Photo { get; set; }
        public int? RequestId { get; set; }
        public Request Request { get; set; }
    }    
}
