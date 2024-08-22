using TelemetryPortal.Components.Pages.Projects;
using TelemetryPortal.Models;

namespace TelemetryPortal.Repository
{
    public interface IProjectsRepository
    {
        Task<IEnumerable<TelemetryPortal.Models.Project>> GetAllProjectsAsync();
        Task<TelemetryPortal.Models.Project> GetByIdAsync(int ProjectID);
        Task<TelemetryPortal.Models.Project> InsertAsync(Project project);
       Task <TelemetryPortal.Models.Project> UpdateAsync(Project project);
       Task DeleteAsync(int ProjectID);
    }
}
