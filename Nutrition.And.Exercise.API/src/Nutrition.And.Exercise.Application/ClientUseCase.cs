using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Borders.Interfaces.UseCases;

namespace Nutrition.And.Exercise.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IClientRepository clientRepository;
        public ClientUseCase(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetCustomersAsync()
        {
            var response = await clientRepository.GetCustomersAsync();
            return response;
        }

        public async Task<ClientResponse> GetClientAsync(Guid id)
        {
            var response = await clientRepository.GetClientAsync(id);
            return response;
        }
    }
}
