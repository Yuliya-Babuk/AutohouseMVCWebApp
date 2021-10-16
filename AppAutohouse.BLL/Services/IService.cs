using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        Task AddNewAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);

    }
}