using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Poker.Domain.Repositories;
using Poker.Infra.Config;
using System.Linq.Expressions;

namespace Poker.Infra.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbSet<TModel> _set;

        protected readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
            _set = _context.Set<TModel>();
        }

        public async Task<TModel?> FindAsync(params object?[]? id)
        {
            return await _set.FindAsync(id);
        }

        public async Task AddAsync(params TModel[] models)
        {
            await _set.AddRangeAsync(models);
        }
        public void Delete(params TModel[] models)
        {
            _set.RemoveRange(models);
        }

        public async Task UpdateWhereAsync(Expression<Func<TModel, bool>> filter,
            Func<SetPropertyCalls<TModel>, SetPropertyCalls<TModel>> setProperties)
        {
            await _set.Where(filter).ExecuteUpdateAsync(setter => setProperties(setter));
        }

        public void Update(params TModel[] models)
        {
            _set.UpdateRange(models);
        }
    }
}
