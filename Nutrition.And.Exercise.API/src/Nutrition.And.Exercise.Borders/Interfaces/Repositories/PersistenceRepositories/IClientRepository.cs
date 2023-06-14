using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Data;

namespace Nutrition.And.Exercise.Borders.Interfaces.Repositories.PersistenceRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ClientResponse> GetClientAsync(Guid id);
        Task<IEnumerable<Client>> GetCustomersAsync();
        void InsertCustomer(Client client);
    }
}
