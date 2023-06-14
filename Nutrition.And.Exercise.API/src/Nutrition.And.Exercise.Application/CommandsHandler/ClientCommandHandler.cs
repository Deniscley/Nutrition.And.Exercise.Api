using FluentValidation.Results;
using MediatR;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Application.Events;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Core.Messages;

namespace Nutrition.And.Exercise.Application.CommandsHandler
{
    public class ClientCommandHandler : CommandHandler, 
        IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;
        public ClientCommandHandler(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        
        }
        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.Nome, message.DataNascimento);

            // Validações de negócio
            var existingCustomer = await _clientRepository.GetClientAsync(message.Id);

            if (existingCustomer != null)
            {
                AddError("Este Cliente já existe.");
                return ValidationResult;
            }

            _clientRepository.InsertCustomer(client);

            client.AddEvent(new RegisteredCustomerEvent(message.Id, message.Nome, message.DataNascimento));

            return await PersistData(_clientRepository.UnitOfWork);
        }
    }
}
