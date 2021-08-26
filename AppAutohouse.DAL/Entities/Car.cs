using System.ComponentModel.DataAnnotations;
using FluentValidation;
using AppAutohouse.DAL.Validators;


namespace MVCAppAutohouse.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        [Required]
        public string Model { get; set; }
        public EngineType EngineType { get; set; }
        [Required]
        public double? EngineSize { get; set; }
        [Required]
        [Range(2010,2021)]
        public int? Year { get; set; }
        [Required]
        public int? Price { get; set; }

    }
    public enum EngineType
    {
        Petrol,
        Diesel,
        Gas,
        Electro
    }
}
