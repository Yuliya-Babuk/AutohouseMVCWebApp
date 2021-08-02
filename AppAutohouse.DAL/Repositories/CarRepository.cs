using AppAutohouse.DAL.Context;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly AutohouseContext _context;

        public CarRepository(AutohouseContext context)
        {
            _context = context;
        }

        public void AddNew(Car item)
        {
            _context.Cars.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Car carToDelete = _context.Cars.FirstOrDefault(x => x.Id == Id);
            if (!(carToDelete == null))
            {
                _context.Cars.Remove(carToDelete);
                _context.SaveChanges();
            }

        }
        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.Include(x=>x.Brand);

        }
        public void Update(Car car)
        {
            var carToUpdate = _context.Cars.FirstOrDefault(r => r.Id == car.Id);
            _context.Entry(carToUpdate).CurrentValues.SetValues(car);
            _context.SaveChanges();

        }
    }
}
