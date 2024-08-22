<<<<<<< HEAD
﻿using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> cc7a4de7b06adad18bc9fb047dc96a39d208af56
using TelemetryPortal.Data;
using TelemetryPortal.Models;

namespace TelemetryPortal.Repository
{
<<<<<<< HEAD
    public class ClientsRepository : IClientsRepository
=======
    public class ClientsRepository :IClientsRepository
>>>>>>> cc7a4de7b06adad18bc9fb047dc96a39d208af56
    {
        private readonly TechtrendsContext techtrendsContext;

        public ClientsRepository(TechtrendsContext techtrendsContext)
        {
            this.techtrendsContext = techtrendsContext;
        }


        public async Task<IEnumerable<TelemetryPortal.Models.Client>> GetAllClientsAsync()
        {
            return await techtrendsContext.Clients.ToListAsync();
        }


<<<<<<< HEAD
        public async Task<TelemetryPortal.Models.Client> GetByIdAsync(int ClientID)
        {
            return await techtrendsContext.Clients.FindAsync(ClientID);
=======
        public async Task<TelemetryPortal.Models.Client> GetByIdAsync(int ClientId)
        {
            return await techtrendsContext.Clients.FindAsync(ClientId);
>>>>>>> cc7a4de7b06adad18bc9fb047dc96a39d208af56
        }

        public async Task<TelemetryPortal.Models.Client> InsertAsync(TelemetryPortal.Models.Client client)
        {
            techtrendsContext.Clients.Add(client);
            await techtrendsContext.SaveChangesAsync();
            return client;
        }

        public async Task<TelemetryPortal.Models.Client> UpdateAsync(TelemetryPortal.Models.Client client)
        {
            var existingClient = await techtrendsContext.Clients.FindAsync(client.ClientId);
            if (existingClient != null)
            {
                throw new Exception("Client not found");
            }

            existingClient.ClientName = client.ClientName;

            techtrendsContext.Entry(existingClient).State = EntityState.Modified;
            await techtrendsContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(int ClientId)
        {
<<<<<<< HEAD
            var clientToDelete = await techtrendsContext.Clients.FindAsync(ClientId);

            if (clientToDelete != null)
            {
                techtrendsContext.Clients.Remove(clientToDelete);
=======
            var ClientToDelete = await techtrendsContext.Clients.FindAsync(ClientId);

            if (ClientToDelete != null)
            {
                techtrendsContext.Clients.Remove(ClientToDelete);
>>>>>>> cc7a4de7b06adad18bc9fb047dc96a39d208af56
                await techtrendsContext.SaveChangesAsync();
            }
            else
            {
<<<<<<< HEAD
                //Handle client not found scenario (e.g., throw an exception)
=======
                //Handle project not found scenario (e.g., throw an exception)
>>>>>>> cc7a4de7b06adad18bc9fb047dc96a39d208af56
                throw new Exception("Client not found");
            }

        }
    }
}
