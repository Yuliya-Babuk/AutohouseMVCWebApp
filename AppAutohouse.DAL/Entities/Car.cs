namespace MVCAppAutohouse.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string TypeEngine { get; set; }
        public double EngineSize { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

    }
}
