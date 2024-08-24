
namespace TelemetryPortal.Repository
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllClientsAsync();
        Task<TEntity> GetByIdAsync(Guid ClientId);
        Task<TEntity> InsertAsync(TEntity client);
        Task<TEntity> UpdateAsync(TEntity client);
        Task DeleteAsync(Guid ClientId);
        Task SaveChangesAsync();
    }
}