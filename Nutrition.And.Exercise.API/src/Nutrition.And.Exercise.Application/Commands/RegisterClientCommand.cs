using FluentValidation;
using Nutrition.And.Exercise.Borders.Messages;

namespace Nutrition.And.Exercise.Application.Commands
{
    public class RegisterClientCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public RegisterClientCommand(Guid id, string nome, DateTime dataNascimento)
        {
            AggregateId = id;
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
