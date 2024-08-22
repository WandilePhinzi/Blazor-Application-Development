using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;

namespace TelemetryPortal.Repository
{
    public class ClientsRepository :IClientsRepository
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


        public async Task<TelemetryPortal.Models.Client> GetByIdAsync(int ClientId)
        {
            return await techtrendsContext.Clients.FindAsync(ClientId);
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
            var ClientToDelete = await techtrendsContext.Clients.FindAsync(ClientId);

            if (ClientToDelete != null)
            {
                techtrendsContext.Clients.Remove(ClientToDelete);
                await techtrendsContext.SaveChangesAsync();
            }
            else
            {
                //Handle project not found scenario (e.g., throw an exception)
                throw new Exception("Client not found");
            }

        }
    }
}
