using AppAutohouse.DAL.Context;
using AppAutohouse.DAL.Entities;
using AppAutohouse.DAL.Repositories;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class BrandRepository : AbstractRepository<Brand>
    {
        public BrandRepository(AutohouseContext context) : base(context)
        {
        }
    }
}
         