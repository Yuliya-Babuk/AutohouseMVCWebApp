using AppAutohouse.DAL.Entities;
using AppAutohouse.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll(include:x=>x.Include(x=>x.Brand));
        }

        public IEnumerable<Car> GetAllByBrandId(int id)
        {
            return _carRepository.GetAll(predicate:x=>x.BrandId ==id, include: x => x.Include(x => x.Brand),IsTracking: false);;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return  await _carRepository.GetByPredicateAsync(include:x=>x.Include(x=>x.Brand),predicate:x=>x.Id == id,IsTracking:false);
        }


        public IEnumerable<Car> SearchAsync(string searchLine)
        {
            if(string.IsNullOrEmpty(searchLine))
                return _carRepository.GetAll(include: x => x.Include(x => x.Brand), IsTracking: false);


            var splitedSearchLine = searchLine.Split(" ");
            List<Car> result = new List<Car>();
            foreach (string partionLine in splitedSearchLine)
            {
                result.AddRange(_carRepository.GetAll(
                predicate: x => (x.Brand.Name.Contains(partionLine, StringComparison.OrdinalIgnoreCase))
                || (x.Model.Contains(partionLine, StringComparison.OrdinalIgnoreCase))
                || (x.EngineSize.ToString().Contains(partionLine, StringComparison.OrdinalIgnoreCase))
            , include: x => x.Include(x => x.Brand), IsTracking: false));

            }
            var uniqueResult= result
                .GroupBy(x => x.Id)
                  .Select(x => x.First());
            return uniqueResult;

        }      

        public async Task UpdateAsync(Car item)
        {
          await  _carRepository.UpdateAsync(item);
        }
    }

}



