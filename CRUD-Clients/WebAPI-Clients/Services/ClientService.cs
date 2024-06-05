using Microsoft.EntityFrameworkCore;
using DBContext;
using Models;
using WebAPI_Clients.Repository.Interfaces;
using WebAPI_Clients.Services.Interfaces;

namespace WebAPI_Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return _clientRepository.GetAllAsync();
        }

        public Task<Client> GetClientByIdAsync(int id)
        {
            return _clientRepository.GetByIdAsync(id);
        }

        public Task AddClientAsync(Client client)
        {
            client.State = "Activo";
            return _clientRepository.AddAsync(client);
        }

        public Task UpdateClientAsync(Client client)
        {
            return _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client != null)
            {
                client.State = "Eliminado";
                await _clientRepository.UpdateAsync(client);
            }
        }
    }
}
