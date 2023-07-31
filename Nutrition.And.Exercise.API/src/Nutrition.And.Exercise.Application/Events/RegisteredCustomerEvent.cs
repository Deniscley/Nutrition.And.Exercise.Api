using Nutrition.And.Exercise.Core.DomainObjects;
using Nutrition.And.Exercise.Core.Messages;

namespace Nutrition.And.Exercise.Application.Events
{
    public class RegisteredCustomerEvent : DomainEvent
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public RegisteredCustomerEvent(Guid aggregateId, string nome, DateTime dataNascimento) : base(aggregateId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
