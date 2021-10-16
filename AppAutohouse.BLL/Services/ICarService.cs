using AppAutohouse.DAL.Entities;
using System.Collections.Generic;

namespace AppAutohouse.BLL
{
    public interface ICarService : IService<Car>
    {
        IEnumerable<Car> SearchAsync(string searchLine);
        IEnumerable<Car> GetAllByBrandId(int id);
      
    }
}