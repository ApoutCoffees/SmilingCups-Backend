namespace SmilingCup_Backend.Shared.domain.repositories;

public interface IUnitOfWork
{
    /// <summary>
    ///     Save changes to the repository
    /// </summary>
    /// <returns></returns>
    Task CompleteAsync();
}