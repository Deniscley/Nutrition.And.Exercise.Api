using FluentValidation.Results;
using MediatR;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Borders.Commands
{
    public class ClientCommandHandler : CommandHandler, 
        IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.Nome, message.DataNascimento);

            // Validações de negócio

            // Persistir no banco!

            if (true) // Já existe um cliente com o id informado
            {
                AddError("Este Id já está em uso.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}
