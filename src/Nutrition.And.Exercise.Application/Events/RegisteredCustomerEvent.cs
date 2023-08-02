using Nutrition.And.Exercise.Core.Messages;
using Nutrition.And.Exercise.Core.Messages.CommonMessages.DomainEvents;

namespace Nutrition.And.Exercise.Application.Events
{
    public class RegisteredCustomerEvent : DomainEvent
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf;

        public RegisteredCustomerEvent(Guid aggregateId, string nome, DateTime dataNascimento, string cpf) : base(aggregateId)
        {
            AggregateId = aggregateId;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }
    }
}
