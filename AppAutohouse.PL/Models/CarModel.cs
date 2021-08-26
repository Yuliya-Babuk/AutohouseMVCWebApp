using AppAutohouse.PL.Mappers;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
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
        [Range(2010, 2021)]
        public int? Year { get; set; }
        [Required]
        public int? Price { get; set; }        
    }    
}
