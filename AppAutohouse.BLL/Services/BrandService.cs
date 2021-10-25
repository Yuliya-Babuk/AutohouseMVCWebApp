using AppAutohouse.DAL.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using MVCAppAutohouse.DAL.Repositories;
using AppAutohouse.DAL.Entities;

namespace AppAutohouse.BLL
{
    public class BrandService : IBrandService

    {
        private readonly BrandRepository _brandRepository;

        public BrandService(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task AddNewAsync(Brand item)
        {
           await _brandRepository.AddNewAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
          await  _brandRepository.DeleteAsync(id);
        }
        public IEnumerable<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }
        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _brandRepository.GetByPredicateAsync( x=> x.Id == id, IsTracking: false);
        }

        public async Task UpdateAsync(Brand item)
        {
                    
           
                await _brandRepository.UpdateAsync(item);
            
           
        }
    }
}



