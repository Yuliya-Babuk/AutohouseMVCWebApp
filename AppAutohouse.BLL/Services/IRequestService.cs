using MVCAppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public interface IRequestService : IService<Request>
    {
        Task ConfirmAsync(int id);
        Task DeclineAsync(int id);
        IEnumerable<Request> GetAllConfirmed();
        IEnumerable<Request> GetAllDeclined();
    }
}