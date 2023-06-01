using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Repository;
using Nutrition.And.Exercise.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext context;

        public ClientRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Client>> GetCustomersAsync()
        {
            return await context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetClientAsync(Guid id)
        {
            return await context.Customers.FindAsync(id);
        }
    }
}
