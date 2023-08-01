using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Core.Data;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ClientResponse> GetClientAsync(Guid id);
        Task<IEnumerable<ClientResponse>> GetCustomersAsync();
        void InsertCustomer(Client client);
    }
}
