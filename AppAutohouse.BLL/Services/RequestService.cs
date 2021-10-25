using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public class RequestService : IRequestService

    {
        private readonly RequestRepository _requestRepository;


        public RequestService(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;

        }

        public async Task AddNewAsync(Request request)
        {
            await _requestRepository.AddNewAsync(request);

        }

        public async Task ConfirmAsync(int id)
        {
            Request request = await _requestRepository.GetByPredicateAsync(predicate: x => x.Id == id);
            if (request != null)
            {
                request.RequestState = RequestState.Confirmed;
                await _requestRepository.UpdateAsync(request);
            }
        }

        public async Task DeclineAsync(int id)
        {
            Request request = await _requestRepository.GetByPredicateAsync(predicate: x => x.Id == id);
            if (request != null)
            {
                request.RequestState = RequestState.Declined;
                await _requestRepository.UpdateAsync(request);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _requestRepository.DeleteAsync(id);
        }
        public IEnumerable<Request> GetAll()
        {

            return _requestRepository.GetAll(predicate: x => x.RequestState == RequestState.None, IsTracking: false);
        }
        public IEnumerable<Request> GetAllConfirmed()
        {

            return _requestRepository.GetAll(predicate: x => x.RequestState == RequestState.Confirmed, IsTracking: false);
        }
        public IEnumerable<Request> GetAllDeclined()
        {

            return _requestRepository.GetAll(predicate: x => x.RequestState == RequestState.Declined, IsTracking: false);
        }
        public async Task<Request> GetByIdAsync(int id)
        {
            return await _requestRepository.GetByPredicateAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Request request)
        {
            await _requestRepository.UpdateAsync(request);
        }
    }

}



