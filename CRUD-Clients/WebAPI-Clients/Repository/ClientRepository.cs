using Microsoft.EntityFrameworkCore;
using DBContext;
using Models;
using System;
using WebAPI_Clients.Repository.Interfaces;

namespace WebAPI_Clients.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsDbContext _context;

        public ClientRepository(ClientsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
