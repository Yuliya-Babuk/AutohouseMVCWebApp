using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public interface IService<T>
    {
        (IEnumerable<T>,int) GetAll(int pageNumber = 1, int takeAmount = 20);
        Task AddNewAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);

    }
}