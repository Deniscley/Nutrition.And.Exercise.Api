using Nutrition.And.Exercise.Core.Messages;

namespace Nutrition.And.Exercise.Application.Events
{
    public class RegisteredCustomerEvent : Event
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public RegisteredCustomerEvent(Guid id, string nome, DateTime dataNascimento)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
