using AppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            await _brandRepository.DeleteAsync(id);
        }
        public (IEnumerable<Brand>, int) GetAll(int pageNumber, int takeAmount)
        {
            int skipAmount = (pageNumber - 1) * takeAmount;
            return _brandRepository.GetAll(skipAmount: skipAmount, takeAmount: takeAmount, IsTracking: false);
        }
        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _brandRepository.GetByPredicateAsync(x => x.Id == id, IsTracking: false);
        }

        public async Task UpdateAsync(Brand item)
        {
            await _brandRepository.UpdateAsync(item);

        }
    }
}



