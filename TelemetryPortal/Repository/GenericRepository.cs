using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;

namespace TelemetryPortal.Repository
{
    // A generic repository implementation for managing entities in the database.
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ITechTrendsContext techtrendsContext;

        // Retrieves all entities from the database.
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await techtrendsContext.Set<TEntity>().ToListAsync();
        }
        // Retrieves a specific entity by its unique identifier.
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await techtrendsContext.Set<TEntity>().FindAsync(id);
        }
        // Inserts a new entity into the database.
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            techtrendsContext.Set<TEntity>().Add(entity);
            await techtrendsContext.SaveChangesAsync();
            return entity;
        }
        // Updates an existing entity in the database.
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            // Assuming the entity has a primary key property named "Id"
            var existingEntity = await techtrendsContext.Set<TEntity>().FindAsync(entity);
            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }
            // Updates the existing entity with the values from the provided entity
            techtrendsContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await techtrendsContext.SaveChangesAsync();
            return entity;
        }
        // Deletes a specific entity from the database by its unique identifier.
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
                throw new Exception("Entity not found");
            }
        }
        // Saves all changes made in the context to the database.
        public async Task SaveChangesAsync()
        {
            await techtrendsContext.SaveChangesAsync();
        }
    }
}
