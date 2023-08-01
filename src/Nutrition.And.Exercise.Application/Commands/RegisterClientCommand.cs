using FluentValidation;
using Nutrition.And.Exercise.Core.Messages;

namespace Nutrition.And.Exercise.Application.Commands
{
    /// <summary>
    /// Object used to register clients.
    /// </summary>
    public class RegisterClientCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public RegisterClientCommand(Guid id, string nome, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public override bool EhValid()
        {
            ValidationResult = new RegisterClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterClientValidation : AbstractValidator<RegisterClientCommand>
        {
            public RegisterClientValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado");
            }
        }
    }
}
