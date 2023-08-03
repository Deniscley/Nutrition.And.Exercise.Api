using FluentValidation.Results;
using MediatR;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Core.Messages;
using Nutrition.And.Exercise.Application.Events;

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

            var client = new Client(message.Id, message.Nome, message.DataNascimento, message.Cpf);

            var existingCustomer = await _clientRepository.GetByCpf(message.Cpf);

            if (existingCustomer != null)
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }

            _clientRepository.InsertClients(client);

            //client.AddEvent(new RegisteredCustomerEvent(message.Id, message.Nome, message.DataNascimento, message.Cpf));

            return await PersistData(_clientRepository.UnitOfWork);
        }
    }
}
