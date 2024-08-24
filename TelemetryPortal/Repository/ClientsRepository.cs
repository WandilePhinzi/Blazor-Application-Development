using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;
using System;
using TelemetryPortal.Components.Pages.Clients;
using Microsoft.Identity.Client;

namespace TelemetryPortal.Repository
{

    public class ClientsRepository : IRepository <Client>
    {
        private readonly TechtrendsContext techtrendsContext;


        public ClientsRepository(TechtrendsContext techtrendsContext)
        {
            this.techtrendsContext = techtrendsContext;
        }


        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await techtrendsContext.Clients.ToListAsync();
        }



        public async Task<Client> GetByIdAsync(Guid ClientId)
        {
            return await techtrendsContext.Set<Client>().FindAsync(ClientId);
        }


        public async Task<Client> InsertAsync(Client client)
        {
            techtrendsContext.Set<Client>().Add(client);
            await techtrendsContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            var existingClient = await techtrendsContext.Set<Client>().FindAsync(client.ClientId);
            if (existingClient == null)
            {
                throw new Exception("Client not found");
            }
            existingClient.ClientName = client.ClientName;
            techtrendsContext.Entry(existingClient).State = EntityState.Modified;
            await techtrendsContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(Guid ClientId)
        {

            var clientToDelete = await techtrendsContext.Set<Client>().FindAsync(ClientId);

            if (clientToDelete != null)
            {
                techtrendsContext.Set<Client>().Remove(clientToDelete);

                var ClientToDelete = await techtrendsContext.Set<Client>().FindAsync(ClientId);

                if (ClientToDelete != null)
                {
                    techtrendsContext.Set<Client>().Remove(ClientToDelete);

                    await techtrendsContext.SaveChangesAsync();
                }
                else
                {

                    throw new Exception("Client not found");
                }
               
            }
        }
        public async Task SaveChangesAsync()
        {
            await techtrendsContext.SaveChangesAsync();
        }
    }
}