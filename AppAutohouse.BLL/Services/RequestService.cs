using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using MVCAppAutohouse.DAL.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public (IEnumerable<Request>, int) GetAll(int pageNumber, int takeAmount)
        {

            int skipAmount = (pageNumber - 1) * takeAmount;
            return _requestRepository.GetAll(predicate: x => x.RequestState == RequestState.None, include: x => x.Include(x => x.Car).ThenInclude(x => x.Brand), IsTracking: false, takeAmount: takeAmount, skipAmount: skipAmount);

        }
        public (IEnumerable<Request>, int) GetAllConfirmed(int pageNumber, int takeAmount)
        {
            int skipAmount = (pageNumber - 1) * takeAmount;
            return _requestRepository.GetAll(predicate: x => x.RequestState == RequestState.Confirmed, include: x => x.Include(x => x.Car).ThenInclude(x => x.Brand), IsTracking: false, takeAmount: takeAmount, skipAmount: skipAmount);
        }
        public (IEnumerable<Request>, int) GetAllDeclined(int pageNumber, int takeAmount)
        {
            int skipAmount = (pageNumber - 1) * takeAmount;
            return _requestRepository.GetAll(predicate: x => x.RequestState == RequestState.Declined, include: x => x.Include(x => x.Car).ThenInclude(x => x.Brand), IsTracking: false, takeAmount: takeAmount, skipAmount: skipAmount);
        }
        public async Task<Request> GetByIdAsync(int id)
        {
            return await _requestRepository.GetByPredicateAsync(x => x.Id == id);
        }

        public Stream GetCsvContent()
        {
            var requests = GetAll(1, int.MaxValue).Item1;
            var sb = new StringBuilder();
            foreach (var request in requests)
            {
                sb.AppendLine($"{request.Name},{request.Surname},{request.PhoneNumber}\t" +
                    $",{request.Car.Brand.Name} {request.Car.Model},{request.Car.Year}");
            }
            return GenerateStreamFromString(sb.ToString());
        }

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public async Task UpdateAsync(Request request)
        {
            await _requestRepository.UpdateAsync(request);
        }
    }

}



