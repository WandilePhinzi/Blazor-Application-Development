
namespace TelemetryPortal.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Retrieves all entities from the repository.
        Task<IEnumerable<TEntity>> GetAllAsync();
        // Retrieves a specific entity by its unique identifier.
        Task<TEntity> GetByIdAsync(Guid id);
        // Inserts a new entity into the repository.
        Task<TEntity> InsertAsync(TEntity entity);
        // Updates an existing entity in the repository.
        Task<TEntity> UpdateAsync(TEntity entity);
        // Deletes a specific entity from the repository by its unique identifier.
        Task DeleteAsync(Guid id);
        // Saves all changes made in the repository to the database.
        Task SaveChangesAsync();
    }

}