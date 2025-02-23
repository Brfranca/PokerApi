using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Poker.Domain.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<TModel?> FindAsync(params object?[]? id);
        Task AddAsync(params TModel[] models);
        void Delete(params TModel[] models);
        void Update(params TModel[] models);
        Task UpdateWhereAsync(Expression<Func<TModel, bool>> filter,
           Func<SetPropertyCalls<TModel>, SetPropertyCalls<TModel>> setProperties);
    }
}
