namespace AllVersusOne.Infrastructure.DataAccess;

public interface IUnitOfWorkManager
{
    /// <summary>
    /// Start a new unit of work.
    /// </summary>
    /// <returns>A new unit of work.</returns>
    IUnitOfWork Begin();

    /// <summary>
    /// Get the current unit of work.
    /// </summary>
    /// <returns>Current unit of work.</returns>
    /// <exception cref="System.InvalidOperationException"></exception>
    IUnitOfWork Current();
}

