using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using TelemetryPortal.Models;

namespace TelemetryPortal.Data
{
    public interface ITechTrendsContext
    {
        //The database properties representing tables in the database
        DbSet<Client> Clients { get; set; }
        DbSet<Project> Projects { get; set; }
        Task<int> SaveChangesAsync();
        //This method gets the DbSet for any entity type
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //This method begins a database transaction
        Task<IDbContextTransaction> BeginTransactionAsync();
        // Method to get an entry for any entity type
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
