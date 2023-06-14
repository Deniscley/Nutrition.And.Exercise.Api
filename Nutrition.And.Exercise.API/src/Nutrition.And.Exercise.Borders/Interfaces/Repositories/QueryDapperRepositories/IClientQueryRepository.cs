using Nutrition.And.Exercise.Borders.Entities;

namespace Nutrition.And.Exercise.Borders.Interfaces.Repositories.QueryRepositories
{
    public interface IClientQueryRepository
    {
        Task InsertCustomer(Client client);
        //Task<IEnumerable<Client>> GetCustomersAsync();
        Task<Client?> GetClientAsync(Guid id);

    }
}
