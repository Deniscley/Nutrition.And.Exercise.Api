using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Nutrition.And.Exercise.Api.Controllers;
using Nutrition.And.Exercise.Core.Mediator;
using Nutrition.And.Exercise.Data.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Domain.Dtos.Response;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.QueryDapperRepositories;
using Nutrition.And.Exercise.FakeData.ClientData;
using Xunit;

namespace Nutrition.And.Exercise.Tests.Controllers
{
    public class CustomersControllerTest
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueriesRepository _clientQueriesRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly CustomersController _controler;
        private readonly ClientResponse _client;
        private readonly List<ClientResponse> _clients;

        public CustomersControllerTest()
        {
            _clientRepository = Substitute.For<IClientRepository>();
            _clientQueriesRepository = Substitute.For<IClientQueriesRepository>();
            _mediatorHandler = Substitute.For<IMediatorHandler>();
            _controler = new CustomersController(_clientRepository,
                _clientQueriesRepository, _mediatorHandler);

            _client = new ClientFaker().Generate();
            _clients = new ClientFaker().Generate(10);
        }

        [Fact]
        public async Task Get_Ok()
        {
            var control = new List<ClientResponse>();
            _clients.ForEach(c => control.Add(c.TypedClone()));

            _clientRepository.GetCustomersAsync().Returns(_clients);
            var result = (ObjectResult) await _controler.Get();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(control);
        }
    }
}
 