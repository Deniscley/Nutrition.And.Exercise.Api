using Moq;
using Moq.AutoMock;
using NSubstitute;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Application.CommandsHandler;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.FakeData.Commands;
using Xunit;

namespace Nutrition.And.Exercise.Tests.CommandsHandler
{
    public class ClientCommandHandlerTest
    {
        private readonly IClientRepository _clientRepository;
        private readonly RegisterClientCommand _registerClientCommand;
        private readonly RegisterClientCommandFaker _registerClientCommandFaker;

        private readonly Mock<ClientCommandHandler> _clientCommandHandler;

        public ClientCommandHandlerTest()
        {
            _clientRepository = Substitute.For<IClientRepository>();
            _registerClientCommandFaker = new RegisterClientCommandFaker();

            _clientCommandHandler = new Mock<ClientCommandHandler>();

            _registerClientCommand = _registerClientCommandFaker.Generate();
        }

        //[Fact]
        //public async Task Client_InsertCustomer_Sucess()
        //{

        //    var message = _registerClientCommand;
        //    var client = new Client(message.Id, message.Nome, message.DataNascimento);

        //    _clientRepository.GetClientAsync(client.Id);

        //    _clientRepository.InsertCustomer(client);
        //}
    }
}
