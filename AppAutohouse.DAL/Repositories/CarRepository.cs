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
            return _context.Cars.AsNoTracking().Include(x => x.Brand);

        }
        public Car GetById(int id)
        {
            var res = _context.Cars.Include(x => x.Brand).FirstOrDefault(x => x.Id == id);
            return res;
        }

            public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
