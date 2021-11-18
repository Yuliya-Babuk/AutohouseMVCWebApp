using AppAutohouse.DAL.Context;
using AppAutohouse.DAL.Entities;
using AppAutohouse.DAL.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAppAutohouse.DAL.Repositories
{
    public class CarRepository : AbstractRepository<Car>
    {
        public CarRepository(AutohouseContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Car>, int)> SearchAsync(string searchLine, int pageNumber, int takeAmount)
        {

            int skipAmount = (pageNumber - 1) * takeAmount;
            if (string.IsNullOrEmpty(searchLine))
                return GetAll(predicate: x => x.Request == null, include: x => x.Include(x => x.Brand).Include(x => x.Request), IsTracking: false, takeAmount: takeAmount, skipAmount: skipAmount);


            var splitedSearchLine = searchLine.Split(" ");
            var expression = PredicateBuilder.New<Car>();
            List<Car> result = new List<Car>();
            // var query = table.Include(c => c.Brand).AsQueryable();
            foreach (string partionLine in splitedSearchLine)
            {
                //TODO: OrdinaryCase + pagination
                expression = expression.Or(x => (x.Brand.Name.Contains(partionLine)));
                expression = expression.And(x => x.Model.Contains(partionLine));
                expression = expression.And(x => x.EngineSize.ToString().Contains(partionLine));
                expression = expression.And(x => x.Request==null);

            }
            //var sql = query.ToQueryString();
            var uniqueResult = await table.Include(c => c.Brand).Include(x=>x.Request).Where(expression).Distinct().Skip(skipAmount).Take(takeAmount).ToListAsync();
            var count = await table.CountAsync(expression);

            return (uniqueResult, count);
        }
    }
}