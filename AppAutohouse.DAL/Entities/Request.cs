using AppAutohouse.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCAppAutohouse.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public RequestState RequestState { get; set; }

    }

    public enum RequestState
    {
        None,
        Confirmed,
        Declined
    }
}
