using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;

namespace TelemetryPortal.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TechtrendsContext techtrendsContext;

        public async Task<IEnumerable<TEntity>> GetAllClientsAsync()
        {
            return await techtrendsContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await techtrendsContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity client)
        {
            techtrendsContext.Set<TEntity>().Add(client);
            await techtrendsContext.SaveChangesAsync();
            return client;
        }
        public async Task<TEntity> UpdateAsync(TEntity client)
        {
            var existingEntity = await techtrendsContext.Set<TEntity>().FindAsync(client);
            if (existingEntity == null)
            {
                throw new Exception("Client not found");
            }

            techtrendsContext.Entry(existingEntity).CurrentValues.SetValues(client);
            await techtrendsContext.SaveChangesAsync();
            return client;
        }
        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await techtrendsContext.Set<TEntity>().FindAsync(id);

            if (entityToDelete != null)
            {
                techtrendsContext.Set<TEntity>().Remove(entityToDelete);
                await techtrendsContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Client not found");
            }
        }
        public async Task SaveChangesAsync()
        {
            await techtrendsContext.SaveChangesAsync();
        }
    }
}
