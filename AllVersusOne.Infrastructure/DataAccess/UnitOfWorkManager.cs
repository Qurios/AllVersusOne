using AllVersusOne.Infrastructure.Database;
using Microsoft.Extensions.Logging;

namespace AllVersusOne.Infrastructure.DataAccess
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private IUnitOfWork? _unitOfWork;

        public UnitOfWorkManager(
            DatabaseContext databaseContext,
            ILoggerFactory loggerFactory)
        {
            DatabaseContext = databaseContext;
        }

        protected DatabaseContext DatabaseContext { get; }

        public IUnitOfWork Begin()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = CreateUnitOfWork();
            }
            else
            {
                throw new InvalidOperationException("UnitOfWork already exist. This means the code running has encountered two UnitOfWorkManager.Begin().");
            }

            return _unitOfWork;
        }

        public IUnitOfWork Current()
        {
            if (_unitOfWork == null)
            {
                throw new InvalidOperationException("The current unit of work has not been initialized.");
            }

            return _unitOfWork;
        }

        protected virtual IUnitOfWork CreateUnitOfWork()
            => new UnitOfWork(DatabaseContext);
    }
}
