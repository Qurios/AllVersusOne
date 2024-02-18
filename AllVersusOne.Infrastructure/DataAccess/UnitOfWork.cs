using AllVersusOne.Infrastructure.Database;

namespace AllVersusOne.Infrastructure.DataAccess
{
    public class UnitOfWork(DatabaseContext context) : IUnitOfWork
    {
        private bool _disposed = false;

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
