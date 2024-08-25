using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;
using System;
using Microsoft.Identity.Client;

namespace TelemetryPortal.Repository
{
    //This is a repository class for managing Project entites
    //Implements IProjectRepository Interface for CRUD operations
    public class ProjectsRepository : IProjectsRepository <Project>
    {
        //Uses the interface of the TechTrends Context to implement dependency version principle
        private readonly ITechTrendsContext techtrendsContext;

        // Constructor accepting the context as a dependency
        public ProjectsRepository (ITechTrendsContext techtrendsContext)
        {
            this.techtrendsContext = techtrendsContext;
        }

        // Retrieves all Project entities from the database
        public async Task <IEnumerable <Project>> GetAllProjectsAsync()
        {
            return await techtrendsContext.Projects.ToListAsync();
        }

        // Retrieves a Project entity by its ID
        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await techtrendsContext.Set<Project>().FindAsync(id);
        }
        // Inserts a new Project entity into the database
        public async Task <Project> InsertAsync (Project project)
        {
            techtrendsContext.Projects.Add(project);
            await techtrendsContext.SaveChangesAsync();
            return project;
        }
        // Updates an existing Project entity in the database
        public async Task <Project> UpdateAsync (Project project)
        {
            var existingProject = await techtrendsContext.Projects.FindAsync(project.ProjectId);
            if (existingProject != null)
            {
                throw new Exception("Project not found"); // Throw exception if project is not found
            }

            existingProject.ProjectName = project.ProjectName;

            techtrendsContext.Entry(existingProject).State = EntityState.Modified;
            await techtrendsContext.SaveChangesAsync();
            return project;
        }
        // Deletes a Project entity from the database by its ID
        public async Task DeleteAsync (Guid id)
        {
            var projectToDelete = await techtrendsContext.Set<Project>().FindAsync(id);

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
        // Saves all changes made in the context to the database
        public async Task SaveChangesAsync()
        {
            await techtrendsContext.SaveChangesAsync();
        }

    }
}
