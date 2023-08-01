using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Interfaces.Queries;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;

namespace Nutrition.And.Exercise.Application.Queries
{
    public class ClientQueries : IClientQueries
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueriesRepository _clientQueriesRepository;

        public ClientQueries(IClientRepository clientRepository, IClientQueriesRepository clientQueriesRepository)
        {
            _clientRepository = clientRepository;
            _clientQueriesRepository = clientQueriesRepository;
        }

        public async Task<ClientResponse> GetClient(Guid id)
        {
            var response = await _clientQueriesRepository.GetClientAsync(id);

            return response;
        }

        public async Task<IEnumerable<ClientResponse>> GetCustomers()
        {
            var response = await _clientRepository.GetCustomersAsync();

            return response;
        }
    }
}
