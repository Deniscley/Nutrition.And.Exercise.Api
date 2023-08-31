using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Entities;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.MongoDBRepositories
{
    public interface IClientMongoRepository
    {
        Task<ClientResponse> GetByCpf(string cpf);
        Task<IEnumerable<ClientResponse>> GetClientsAsync();
        void InsertClients(Client client);
    }
}
