using NSubstitute;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.FakeData.Commands;

namespace Nutrition.And.Exercise.Tests.CommandsHandler
{
    public class ClientCommandHandlerTest
    {
        private readonly IClientRepository _clientRepository;
        private readonly RegisterClientCommand registerClientCommand;
        private readonly RegisterClientCommandFaker _registerClientCommandFaker;

        public ClientCommandHandlerTest()
        {
            _clientRepository = Substitute.For<IClientRepository>();
            _registerClientCommandFaker = new RegisterClientCommandFaker();

            registerClientCommand = _registerClientCommandFaker.Generate();
        }

        //[Fact]
        //public async Task Client_InsertCustomer_Sucess()
        //{
        //    var message = registerClientCommand;
        //    var client = new Client(message.Id, message.Nome, message.DataNascimento);

        //    _clientRepository.GetClientAsync(client.Id).ReturnsNull();

        //    _clientRepository.InsertCustomer(client);
        //}
    }
}
