using AppAutohouse.PL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppAutohouse.PL.Mappers
{
    public class BrandModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Logo { get; set; }
        public List<CarModel> Cars { get; set; }       

    }
}