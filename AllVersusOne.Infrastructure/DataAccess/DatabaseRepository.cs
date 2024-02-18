using System.Linq.Expressions;
using AllVersusOne.DataModel;
using AllVersusOne.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.Infrastructure.DataAccess
{
    public class DatabaseRepository<TEntity>(DatabaseContext context) : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected DatabaseContext Context { get; } = context;
        protected DbSet<TEntity> DbSet { get; } = context.Set<TEntity>();

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var dbEntityEntry = await DbSet.AddAsync(entity);
            return dbEntityEntry.Entity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IQueryable<TEntity> Many()
        {
            return DbSet.AsQueryable();
        }
    }
}
