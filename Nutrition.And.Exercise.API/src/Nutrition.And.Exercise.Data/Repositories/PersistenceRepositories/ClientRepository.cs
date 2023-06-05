using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Data;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Repositories.PersistenceRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            this._context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Client>> GetCustomersAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetClientAsync(Guid id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void InsertCustomer(Client client)
        {
            _context.Customers.Add(client);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
