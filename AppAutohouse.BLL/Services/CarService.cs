using AppAutohouse.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public class CarService : ICarService

    {
        private readonly CarRepository _carRepository;


        public CarService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task AddNewAsync(Car item)
        {
            await _carRepository.AddNewAsync(item);

        }
        public async Task DeleteAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }
        public (IEnumerable<Car>, int) GetAll(int pageNumber, int takeAmount)
        {
            int skipAmount = (pageNumber - 1) * takeAmount;
            return _carRepository.GetAll(include: x => x.Include(x => x.Brand), IsTracking: false, takeAmount: takeAmount, skipAmount: skipAmount);
        }

        public (IEnumerable<Car> cars, int itemsAmount) GetAllByBrandId(int id)
        {
            return _carRepository.GetAll(predicate: x => x.BrandId == id, include: x => x.Include(x => x.Brand), IsTracking: false); ;
        }
        public (IEnumerable<Car>, int) GetAllForSale(int pageNumber, int takeAmount)
        {
            int skipAmount = (pageNumber - 1) * takeAmount;
            return _carRepository.GetAll(predicate: x => x.Request == null, include: x => x.Include(x => x.Brand).Include(x => x.Request), IsTracking: false, takeAmount: takeAmount, skipAmount: skipAmount);
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _carRepository.GetByPredicateAsync(include: x => x.Include(x => x.Brand), predicate: x => x.Id == id, IsTracking: false);
        }


        public async Task<(IEnumerable<Car> cars, int itemsAmount)> SearchAsync(string searchLine, int pageNumber, int takeAmount)
        {
            return await _carRepository.SearchAsync(searchLine, pageNumber, takeAmount);

        }

        public async Task UpdateAsync(Car item)
        {
            await _carRepository.UpdateAsync(item);
        }
    }

}



