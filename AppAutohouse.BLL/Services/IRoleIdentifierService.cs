using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.BLL
{
    public interface IRoleIdentifierService
    {
        bool IsAdmin();
        bool IsManager();
        
    }
}