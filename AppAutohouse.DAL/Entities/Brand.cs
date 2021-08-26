using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCAppAutohouse.DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Logo { get; set; }
        public List<Car> Cars { get; set; }

        public Brand()
        {
            Cars = new List<Car>();
        }

    }
}
