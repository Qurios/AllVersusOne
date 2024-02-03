using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.Infrastructure.DataAccess
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        IQueryable<TEntity> Many();
    }
}
