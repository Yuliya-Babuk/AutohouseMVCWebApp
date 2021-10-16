using AppAutohouse.DAL.Context;
using AppAutohouse.DAL.Entities;
using AppAutohouse.DAL.Repositories;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class CarRepository : AbstractRepository<Car>
    {
        public CarRepository(AutohouseContext context) : base(context)
        {
        }
    }
}