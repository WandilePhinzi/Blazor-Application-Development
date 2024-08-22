using TelemetryPortal.Components.Pages.Projects;
using TelemetryPortal.Models;

namespace TelemetryPortal.Repository
{
    public interface IClientsRepository
    {
        Task<IEnumerable<TelemetryPortal.Models.Client>> GetAllClientsAsync();
        Task<TelemetryPortal.Models.Client> GetByIdAsync(int ClientId);
        Task<TelemetryPortal.Models.Client> InsertAsync(Client client);
        Task<TelemetryPortal.Models.Client> UpdateAsync(Client client);
        Task DeleteAsync(int ClientId);
    }
}
