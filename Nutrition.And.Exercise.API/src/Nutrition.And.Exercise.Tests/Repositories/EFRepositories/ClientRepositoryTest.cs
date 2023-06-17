using AutoMapper;
using Azure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Data.Context;
using Nutrition.And.Exercise.Data.MappingsProfile;
using Nutrition.And.Exercise.Data.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.FakeData.DTOs;
using Nutrition.And.Exercise.FakeData.Entities;
using Xunit;

namespace Nutrition.And.Exercise.Tests.Repositories.EFRepositories
{
    public class ClientRepositoryTest : IDisposable
    {
        private readonly IClientRepository _repository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly Client _client;
        private readonly ClientResponse _clientResponse;
        private ClientFaker _clientFaker;
        private ClientResponseFaker _clientResponseFaker;


        public ClientRepositoryTest()
        {
            var optionBuider = new DbContextOptionsBuilder<DataContext>();
            optionBuider.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _mapper = new MapperConfiguration(p => p.AddProfile<ClientMappingProfile>()).CreateMapper();

            _context = new DataContext(optionBuider.Options);
            _repository = new ClientRepository(_context, _mapper);

            _clientFaker = new ClientFaker();
            _client = _clientFaker.Generate();
        }

        private async Task<List<Client>> InsertRecords()
        {
            var customers = _clientFaker.Generate(100);
            foreach (var client in customers)
            {
                client.Id = Guid.NewGuid();
                await _context.Customers.AddAsync(client);
            }
            await _context.SaveChangesAsync();
            return customers;
        }

        [Fact]
        public async Task GetCustomersAsync_WithReturn()
        {
            var records = await InsertRecords();
            var result = await _repository.GetCustomersAsync();
            var control = _mapper.Map<List<Client>, IEnumerable<ClientResponse>>(records);

            var total = control.Count();
            result.Should().HaveCount(total);
        }

        [Fact]
        public async Task GetCustomersAsync_Empty()
        {
            var result = await _repository.GetCustomersAsync();
            result.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClientAsync_Found()
        {
            var records = await InsertRecords();
            var result = await _repository.GetClientAsync(records.First().Id);
            var control = _mapper.Map<List<Client>, List<ClientResponse>>(records);

            result.Should().BeEquivalentTo(control.First());
        }

        [Fact]
        public async Task GetClientAsync_NotFound()
        {
            var result = await _repository.GetClientAsync(Guid.NewGuid());
            result.Should().BeNull();
        }

        //[Fact]
        //public void InsertCustomer_Sucess()
        //{
        //    var result = _repository.InsertCustomer(_client);
        //}

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
