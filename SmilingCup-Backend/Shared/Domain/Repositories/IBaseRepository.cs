namespace SmilingCup_Backend.Shared.domain.repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    // Find an entity by its id
    Task<TEntity?> FindByIdAsync(int id); 
    ///     List all entities in the repository
    Task<IEnumerable<TEntity>> ListAsync();

    // Commands
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}