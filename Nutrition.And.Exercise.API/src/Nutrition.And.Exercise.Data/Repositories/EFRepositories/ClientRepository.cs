using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Domain.Dtos.Response;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Core.Data;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Data.Context;

namespace Nutrition.And.Exercise.Data.Repositories.PersistenceRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;

        public ClientRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;   
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<ClientResponse>> GetCustomersAsync()
        {
            var response = await _context.Customers.AsNoTracking().ToListAsync();
            var clientResponse = mapper.Map<List<Client>, IEnumerable<ClientResponse>>(response);
            return clientResponse;

        }

        public async Task<ClientResponse> GetClientAsync(Guid id)
        {
            var response = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            var clientResponse = mapper.Map<Client, ClientResponse>(response);
            return clientResponse;
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
