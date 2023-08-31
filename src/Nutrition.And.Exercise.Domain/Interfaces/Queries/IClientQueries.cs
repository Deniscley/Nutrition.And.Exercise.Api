using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;

namespace Nutrition.And.Exercise.Domain.Interfaces.Queries
{
    public interface IClientQueries
    {
        Task<IEnumerable<ClientResponse>> GetClients();
        Task<ClientResponse> GetClient(Guid id);
    }
}
