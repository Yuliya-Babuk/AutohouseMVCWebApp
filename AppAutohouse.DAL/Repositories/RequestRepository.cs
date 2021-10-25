using AppAutohouse.DAL.Context;
using AppAutohouse.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class RequestRepository : AbstractRepository<Request>

    {
        public RequestRepository(AutohouseContext context) : base(context)
        {
        }

    }
}
