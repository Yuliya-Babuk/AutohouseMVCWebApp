using System.Collections.Generic;

namespace AppAutohouse.BLL
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        void AddNew(T item);
        void Update(T item);
        void Delete(int id);
    }
}