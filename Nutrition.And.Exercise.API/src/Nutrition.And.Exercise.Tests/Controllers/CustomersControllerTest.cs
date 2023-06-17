using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Nutrition.And.Exercise.Api.Controllers;
using Nutrition.And.Exercise.Core.Mediator;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using Nutrition.And.Exercise.FakeData.DTOs;
using Xunit;

namespace Nutrition.And.Exercise.Tests.Controllers
{
    public class CustomersControllerTest
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueriesRepository _clientQueriesRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly CustomersController _controller;
        private readonly ClientResponse _clientResponse;
        private readonly List<ClientResponse> _clientsResponse;

        public CustomersControllerTest()
        {
            _clientRepository = Substitute.For<IClientRepository>();
            _clientQueriesRepository = Substitute.For<IClientQueriesRepository>();
            _mediatorHandler = Substitute.For<IMediatorHandler>();
            _controller = new CustomersController(_clientRepository,
                _clientQueriesRepository, _mediatorHandler);

            _clientResponse = new ClientResponseFaker().Generate();
            _clientsResponse = new ClientResponseFaker().Generate(10);
            _clientResponse = new ClientResponseFaker().Generate();
        }

        [Fact]
        public async Task Get_Ok()
        {
            //Arranje
            var control = new List<ClientResponse>();
            _clientsResponse.ForEach(c => control.Add(c.TypedClone()));
            _clientRepository.GetCustomersAsync().Returns(_clientsResponse);

            //Act
            var result = (ObjectResult)await _controller.Get();

            //Assert
            await _clientRepository.Received().GetCustomersAsync();
            result.Value.Should().BeEquivalentTo(control);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            _clientRepository.GetCustomersAsync().Returns(new List<ClientResponse>());

            var result = (StatusCodeResult)await _controller.Get();

            await _clientRepository.Received().GetCustomersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            _clientQueriesRepository.GetClientAsync(Arg.Any<Guid>()).Returns(_clientResponse.TypedClone());

            var result = (ObjectResult)await _controller.Get(_clientResponse.Id);

            await _clientQueriesRepository.Received().GetClientAsync(Arg.Any<Guid>());
            result.Value.Should().BeEquivalentTo(_clientResponse);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        //[Fact]
        //public async Task Index_Ok()
        //{
        //    await _mediatorHandler
        //        .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Sasuke", DateTime.Now));

        //    var result = (ObjectResult)await _controller.Index();

        //    await _mediatorHandler.Received()
        //        .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Sasuke", DateTime.Now));

        //    Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        //}
    }
}
