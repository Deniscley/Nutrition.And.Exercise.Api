using Nutrition.And.Exercise.Domain.Entities;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.QueryDapperRepositories
{
    public interface IClientQueryRepository
    {
        Task InsertCustomer(Client client);
        //Task<IEnumerable<Client>> GetCustomersAsync();
        Task<Client?> GetClientAsync(Guid id);

    }
}
