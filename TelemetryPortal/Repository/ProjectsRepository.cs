using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;

namespace TelemetryPortal.Repository
{
    public class ProjectsRepository : IProjectsRepository
    {

        private readonly TechtrendsContext techtrendsContext;

        public ProjectsRepository (TechtrendsContext techtrendsContext)
        {
            this.techtrendsContext = techtrendsContext;
        }


        public async Task <IEnumerable <TelemetryPortal.Models.Project>> GetAllProjectsAsync()
        {
            return await techtrendsContext.Projects.ToListAsync();
        }


        public async Task<TelemetryPortal.Models.Project> GetByIdAsync(int projectID)
        {
            return await techtrendsContext.Projects.FindAsync(projectID);
        }

        public async Task <TelemetryPortal.Models.Project> InsertAsync (TelemetryPortal.Models.Project project)
        {
            techtrendsContext.Projects.Add(project);
            await techtrendsContext.SaveChangesAsync();
            return project;
        }

        public async Task <TelemetryPortal.Models.Project> UpdateAsync (TelemetryPortal.Models.Project project)
        {
            var existingProject = await techtrendsContext.Projects.FindAsync(project.ProjectId);
            if (existingProject != null)
            {
                throw new Exception("Project not found");
            }

            existingProject.ProjectName = project.ProjectName;

            techtrendsContext.Entry(existingProject).State = EntityState.Modified;
            await techtrendsContext.SaveChangesAsync();
            return project;
        }

        public async Task DeleteAsync (int projectID)
        {
            var projectToDelete = await techtrendsContext.Projects.FindAsync(projectID);

            if (projectToDelete != null)
            {
                techtrendsContext.Projects.Remove(projectToDelete);
                await techtrendsContext.SaveChangesAsync();
            }
            else
            {
                //Handle project not found scenario (e.g., throw an exception)
                throw new Exception("Project not found");
            }

        }

    }
}
