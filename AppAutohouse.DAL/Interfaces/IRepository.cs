using System.Collections.Generic;

namespace MVCAppAutohouse.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void AddNew(T item);
        void Update(T item);
        void Delete(int id);
        T GetById(int id);       
    }
}
