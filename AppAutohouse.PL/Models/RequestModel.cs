using System.ComponentModel.DataAnnotations;
using MVCAppAutohouse.DAL.Entities;
using AppAutohouse.DAL.Entities;
using Newtonsoft.Json;

namespace AppAutohouse.PL.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [JsonProperty("Phone Number")]
        public string PhoneNumber { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public RequestState RequestState { get; set; }

    }
}
