using Nutrition.And.Exercise.Domain.Dtos.Response;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Core.Data;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ClientResponse> GetClientAsync(Guid id);
        Task<IEnumerable<Client>> GetCustomersAsync();
        void InsertCustomer(Client client);
    }
}
