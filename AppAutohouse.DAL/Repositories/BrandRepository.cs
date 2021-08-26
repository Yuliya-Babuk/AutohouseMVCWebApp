using AppAutohouse.DAL.Context;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly AutohouseContext _context;


        public BrandRepository(AutohouseContext context)
        {
            _context = context;
        }

        public void AddNew(Brand item)
        {
            _context.Brands.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Brand brandToDelete = _context.Brands.FirstOrDefault(x => x.Id == Id);
            if (!(brandToDelete == null))
            {
                _context.Brands.Remove(brandToDelete);
                _context.SaveChanges();
            }

        }
        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands.AsNoTracking();

        }
        public Brand GetById(int id)
        {
            return _context.Brands.Include(x => x.Cars).FirstOrDefault(x => x.Id == id); 
        }
        public void Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}

