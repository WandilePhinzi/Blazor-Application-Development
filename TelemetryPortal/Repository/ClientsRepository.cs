using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;
using System;
using TelemetryPortal.Components.Pages.Clients;
using Microsoft.Identity.Client;

namespace TelemetryPortal.Repository
{
    //This is the Repository class for managing client entites
    //It implements the generic IRepository interface
    public class ClientsRepository : IRepository <Client>
    {
        //Uses the interface of the TechTrends Context to implement dependency version principle
        private readonly ITechTrendsContext techtrendsContext;


        public ClientsRepository(ITechTrendsContext techtrendsContext)
        {
            this.techtrendsContext = techtrendsContext;
        }

        //Retrieves all clients entites from the database 
        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await techtrendsContext.Clients.ToListAsync();
        }


        //Retrieves a Client entity by its ID
        public async Task<Client> GetByIdAsync(Guid Id)
        {
            return await techtrendsContext.Set<Client>().FindAsync(Id);
        }

        //Inserts a new Client entity into the database.
        public async Task<Client> InsertAsync(Client client)
        {
            techtrendsContext.Set<Client>().Add(client);//The inserted Client entity
            await techtrendsContext.SaveChangesAsync();
            return client;
        }

        // Updates an existing Client entity in the database.
        public async Task<Client> UpdateAsync(Client client)
        {
            //The Client entity with updated values
            var existingClient = await techtrendsContext.Set<Client>().FindAsync(client.ClientId);
            if (existingClient == null)
            {
                throw new Exception("Client not found");//Thrown when the Client entity is not found.
            }
            existingClient.ClientName = client.ClientName;
            techtrendsContext.Entry(existingClient).State = EntityState.Modified;
            await techtrendsContext.SaveChangesAsync();
            return client;
        }
        //Deletes a Client entity from the database by its ID.
        public async Task DeleteAsync(Guid Id)
        {
            var clientToDelete = await techtrendsContext.Set<Client>().FindAsync(Id);//The ID of the Client entity to delete.

            if (clientToDelete == null)
            {
                throw new Exception("Client not found");//Thrown when the Client entity is not found
            }

            techtrendsContext.Set<Client>().Remove(clientToDelete);
            await techtrendsContext.SaveChangesAsync();
        }
        //Saves all changes made in the context to the database.
        public async Task SaveChangesAsync()
        {
            await techtrendsContext.SaveChangesAsync();
        }
    }
}