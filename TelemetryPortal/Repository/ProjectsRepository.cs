using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;
using System;
using Microsoft.Identity.Client;

namespace TelemetryPortal.Repository
{
    public class ProjectsRepository : IProjectsRepository <Project>
    {

        private readonly TechtrendsContext techtrendsContext;

        public ProjectsRepository (TechtrendsContext techtrendsContext)
        {
            this.techtrendsContext = techtrendsContext;
        }


        public async Task <IEnumerable <Project>> GetAllProjectsAsync()
        {
            return await techtrendsContext.Projects.ToListAsync();
        }


        public async Task<Project> GetByIdAsync(Guid projectID)
        {
            return await techtrendsContext.Set<Project>().FindAsync(projectID);
        }

        public async Task <Project> InsertAsync (Project project)
        {
            techtrendsContext.Projects.Add(project);
            await techtrendsContext.SaveChangesAsync();
            return project;
        }

        public async Task <Project> UpdateAsync (Project project)
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

        public async Task DeleteAsync (Guid projectID)
        {
            var projectToDelete = await techtrendsContext.Set<Project>().FindAsync(projectID);

            if (projectToDelete != null)
            {
                techtrendsContext.Set<Project>().Remove(projectToDelete);
                await techtrendsContext.SaveChangesAsync();
            }
            else
            {
                //Handle project not found scenario (e.g., throw an exception)
                throw new Exception("Project not found");
            }

        }
        public async Task SaveChangesAsync()
        {
            await techtrendsContext.SaveChangesAsync();
        }

    }
}
