using System.ComponentModel.DataAnnotations;



namespace AppAutohouse.DAL.Entities
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
        [Range(2000, 2021)]
        public int? Year { get; set; }
        [Required]
        public int? Price { get; set; }
        public byte[] Photo { get; set; }

    }
    public enum EngineType
    {
        Petrol,
        Diesel,
        Gas,
        Electro
    }
}
