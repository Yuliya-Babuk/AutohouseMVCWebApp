using AppAutohouse.DAL.Context;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly AutohouseContext context;

        public BrandRepository(AutohouseContext context)
        {
            this.context = context;
        }

        public void AddNew(Brand item)
        {
            context.Brands.Add(item);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Brand brandToDelete = context.Brands.FirstOrDefault(x => x.Id == Id);
            if (!(brandToDelete == null))
            {
                context.Brands.Remove(brandToDelete);
                context.SaveChanges();
            }

        }
        public IEnumerable<Brand> GetAll()
        {
            return context.Brands;

        }
        public void Update(Brand brand)
        {
            var brandToUpdate = context.Brands.FirstOrDefault(r => r.Id == brand.Id);
            context.Entry(brandToUpdate).CurrentValues.SetValues(brand);
            context.SaveChanges();

        }
    }
}
