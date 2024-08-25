namespace TelemetryPortal.Repository
{
    public interface IProjectsRepository<T> where T : class
    {
        //Retrieves all project entities from the repository
        Task<IEnumerable<T>> GetAllProjectsAsync();
        // Retrieves a project entity by its unique identifier.
        Task<T> GetByIdAsync(Guid id);
        // Inserts a new project entity into the repository.
        Task<T> InsertAsync(T project);
        // Updates an existing project entity in the repository.
        Task<T> UpdateAsync(T project);
        // Deletes a project entity from the repository by its unique identifier.
        Task DeleteAsync(Guid id);
        // Saves all changes made in the repository to the database.
        Task SaveChangesAsync();
    }
}
