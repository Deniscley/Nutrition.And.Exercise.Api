﻿using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Core.Data;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ClientResponse> GetByCpf(string cpf);
        Task<IEnumerable<ClientResponse>> GetClientsAsync();
        void InsertClients(Client client);
    }
}
