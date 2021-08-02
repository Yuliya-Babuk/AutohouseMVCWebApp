using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using MVCAppAutohouse.DAL.Repositories;
using System.Collections.Generic;


namespace AppAutohouse.BLL
{
    public class CarService : IService<Car>

    {
        private readonly IRepository<Car> _carRepository;
        

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public void AddNew(Car item)
        {
            _carRepository.AddNew(item);

        }
        public void Delete(int id)
        {
            _carRepository.Delete(id);
        }
        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public void Update(Car item)
        {
            _carRepository.Update(item);
        }
    }
}



