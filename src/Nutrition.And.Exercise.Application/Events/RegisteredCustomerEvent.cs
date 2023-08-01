using Nutrition.And.Exercise.Core.Messages;
using Nutrition.And.Exercise.Core.Messages.CommonMessages.DomainEvents;

namespace Nutrition.And.Exercise.Application.Events
{
    public class RegisteredCustomerEvent : DomainEvent
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public RegisteredCustomerEvent(Guid aggregateId, string nome, DateTime dataNascimento) : base(aggregateId)
        {
            AggregateId = aggregateId;
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
