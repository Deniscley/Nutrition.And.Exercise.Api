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
                client.InsertId(Guid.NewGuid());
                await _context.Customers.AddAsync(client);
            }

            await _context.SaveChangesAsync();

            return customers;
        }

        [Fact(DisplayName = "Clientes com retorno")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetCustomersAsync_WithReturn()
        {
            //Arranje
            var records = await InsertRecords();

            //Act
            var result = await _repository.GetCustomersAsync();
            var control = _mapper.Map<List<Client>, IEnumerable<ClientResponse>>(records);

            //Assert
            var total = control.Count();
            result.Should().HaveCount(total);
        }

        [Fact(DisplayName = "Clientes vazio")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetCustomersAsync_Empty()
        {
            //Act
            var result = await _repository.GetCustomersAsync();

            // Assert
            result.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Clientes encontrados")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetByCpf_Found()
        {
            //Arranje
            var records = await InsertRecords();

            //Act
            var result = await _repository.GetByCpf(records.First().Cpf);
            var control = _mapper.Map<List<Client>, List<ClientResponse>>(records);

            //Assert
            result.Should().BeEquivalentTo(control.First());
        }

        [Fact(DisplayName = "Clientes não encontrados")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetByCpf_NotFound()
        {
            //Act
            var result = await _repository.GetByCpf("23489647821");

            // Assert
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
