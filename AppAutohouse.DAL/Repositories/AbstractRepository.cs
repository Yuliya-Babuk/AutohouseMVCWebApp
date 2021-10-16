using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppAutohouse.DAL.Repositories
{
    public abstract class AbstractRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> table;

        public AbstractRepository(DbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public async Task AddNewAsync(T item)
        {
            if (item != null)
            {
                await table.AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {

            var entity = await table.FindAsync(id);
            if (entity != null)
            {
                table.Remove(entity);
                await _context.SaveChangesAsync();

            }
        }

        public IEnumerable<T> GetAll(
            Func<T, bool> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IsTracking = true)
        {
            if (predicate != null)
            {
                if (include != null)
                {
                    return IsTracking
                        ? include(table).Where(predicate)
                        : include(table).AsNoTracking().Where(predicate);
                }

                return IsTracking
                ? table.Where(predicate)
                : table.AsNoTracking().Where(predicate);
            }
            if (include != null)
            {
                return IsTracking
                    ? (include(table))
                    : (include(table).AsNoTracking());
            }
            return IsTracking
                   ? table
                   : table.AsNoTracking();
        }

        //TODO: refactor code

        public async Task<T> GetByPredicateAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IsTracking = true)
        {
            if (predicate != null)
            {
                if (include != null)
                {
                    return IsTracking
                        ? (await include(table).FirstOrDefaultAsync(predicate))
                        : (await include(table).AsNoTracking().FirstOrDefaultAsync(predicate));
                }
                return IsTracking
                       ? (await table.FirstOrDefaultAsync(predicate))
                       : (await table.AsNoTracking().FirstOrDefaultAsync(predicate));
            }
            return null;
        }

        public async Task UpdateAsync(T item)
        {
            if (item != null)
            {
                table.Update(item);
                await _context.SaveChangesAsync();
            }

        }

    }
}
