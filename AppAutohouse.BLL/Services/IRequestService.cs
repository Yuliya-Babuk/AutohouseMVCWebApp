using MVCAppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public interface IRequestService : IService<Request>
    {
        Task ConfirmAsync(int id);
        Task DeclineAsync(int id);
        (IEnumerable<Request>,int) GetAllConfirmed(int pageNumber, int takeAmount);
        (IEnumerable<Request>, int) GetAllDeclined(int pageNumber, int takeAmount);
        Stream GetCsvContent();
    }
}