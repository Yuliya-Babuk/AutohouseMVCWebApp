using System.Collections.Generic;

namespace MVCAppAutohouse.DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public List<Car> Cars { get; set; }

        public Brand()
        {
            Cars = new List<Car>();
        }

    }
}
