using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using Nutrition.And.Exercise.FakeData.DTOs;
using Xunit;
using Nutrition.And.Exercise.Core.Communication.Mediator;
using Nutrition.And.Exercise.Domain.Interfaces.Queries;
using Nutrition.And.Exercise.Application.Queries;
using Nutrition.And.Exercise.Api.Controllers;
using Nutrition.And.Exercise.Application.Commands;

namespace Nutrition.And.Exercise.Tests.Controllers
{
    public class ClientControllerTest
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueriesRepository _clientQueriesRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IClientQueries _clientQueries;
        private readonly ClientController _controller;
        private readonly ClientResponse _clientResponse;
        private readonly List<ClientResponse> _clientsResponse;

        public ClientControllerTest()
        {
            _clientRepository = Substitute.For<IClientRepository>();
            _clientQueriesRepository = Substitute.For<IClientQueriesRepository>();
            _mediatorHandler = Substitute.For<IMediatorHandler>();
            _clientQueries = Substitute.For<IClientQueries>();
            _controller = new ClientController(
                _mediatorHandler,
                _clientQueries);

            _clientResponse = new ClientResponseFaker().Generate();
            _clientsResponse = new ClientResponseFaker().Generate(10);
        }

        [Fact(DisplayName = "Retorno clientes com sucesso")]
        [Trait("Categoria", "Cliente Controller Trait Testes")]
        public async Task Client_Get_Ok()
        {
            //Arranje
            var control = new List<ClientResponse>();
            _clientsResponse.ForEach(c => control.Add(c.TypedClone()));
            _clientQueries.GetClients().Returns(_clientsResponse);

            //Act
            var result = (ObjectResult)await _controller.Get();

            //Assert
            result.Value.Should().BeEquivalentTo(control);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact(DisplayName = "Clientes não encontrados")]
        [Trait("Categoria", "Cliente Controller Trait Testes")]
        public async Task Client_Get_NotFound()
        {
            //Arranje
            _clientQueries.GetClients().Returns(new List<ClientResponse>());

            //Act
            var result = (StatusCodeResult)await _controller.Get();

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact(DisplayName = "Cliente por id encontrados com sucesso")]
        [Trait("Categoria", "Cliente Controller Trait Testes")]
        public async Task Client_GetById_Ok()
        {
            //Arranje
            _clientQueries.GetClient(Arg.Any<Guid>()).Returns(_clientResponse.TypedClone());

            //Act
            var result = (ObjectResult)await _controller.Get(_clientResponse.Id);

            //Assert
            result.Value.Should().BeEquivalentTo(_clientResponse);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        //[Fact(DisplayName = "Cliente inserido com sucesso")]
        //[Trait("Categoria", "Cliente Controller Trait Testes")]
        //public async Task Client_Post_Ok()
        //{
        //    //Arranje
        //    await _mediatorHandler
        //        .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Sasuke", DateTime.Now));

        //    //Act
        //    var result = (ObjectResult)await _controller.Post();

        //    //Assert
        //}
    }
}
