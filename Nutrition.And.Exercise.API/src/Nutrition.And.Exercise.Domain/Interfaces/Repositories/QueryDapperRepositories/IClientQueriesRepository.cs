using Nutrition.And.Exercise.Domain.Dtos.Response;
using Nutrition.And.Exercise.Domain.Entities;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.QueryDapperRepositories
{
    public interface IClientQueriesRepository
    {
        Task InsertCustomer(Client client);
        //Task<IEnumerable<Client>> GetCustomersAsync();
        Task<ClientResponse> GetClientAsync(Guid id);

    }
}
