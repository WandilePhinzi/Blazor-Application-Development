namespace TelemetryPortal.Repository
{
    public interface IProjectsRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllProjectsAsync();
        Task<T> GetByIdAsync(Guid ProjectID);
        Task<T> InsertAsync(T project);
       Task <T> UpdateAsync(T project);
       Task DeleteAsync(Guid ProjectID);
    }
}
