using AppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public interface ICarService : IService<Car>
    {
        Task<(IEnumerable<Car> cars, int itemsAmount)> SearchAsync(string searchLine, int pageNumber, int takeAmount);
        (IEnumerable<Car> cars, int itemsAmount) GetAllByBrandId(int id);
        (IEnumerable<Car> cars, int itemsAmount) GetAllForSale(int pageNumber, int takeAmount);

    }
}