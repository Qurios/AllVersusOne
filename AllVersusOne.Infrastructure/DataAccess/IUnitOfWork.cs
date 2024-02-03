namespace AllVersusOne.Infrastructure.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
