using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Repository;
using Nutrition.And.Exercise.Borders.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Client> GetClientAsync(int id)
        {
            var response = await clientRepository.GetClientAsync(id);
            return response;
        }
    }
}
