using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Interfaces;
using MVCAppAutohouse.DAL.Repositories;
using System.Collections.Generic;


namespace AppAutohouse.BLL
{
    public class BrandService : IService<Brand>

    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void AddNew(Brand item)
        {
            _brandRepository.AddNew(item);
        }

        public void Delete(int id)
        {
            _brandRepository.Delete(id);
        }
        public IEnumerable<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public void Update(Brand item)
        {
            _brandRepository.Update(item);
        }
    }
}



