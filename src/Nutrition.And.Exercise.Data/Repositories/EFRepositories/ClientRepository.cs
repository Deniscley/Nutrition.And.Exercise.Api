﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Core.Data;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Data.Context;

namespace Nutrition.And.Exercise.Data.Repositories.EFRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<ClientResponse>> GetClientsAsync()
        {
            var response = await _context.Clients.AsNoTracking().ToListAsync();
            var clientsResponse = _mapper.Map<List<Client>, IEnumerable<ClientResponse>>(response);
            return clientsResponse;
        }

        public async Task<ClientResponse> GetByCpf(string cpf)
        {
            var response = await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf);
            var clientResponse = _mapper.Map<Client, ClientResponse>(response);
            return clientResponse;
        }

        public void InsertClients(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
