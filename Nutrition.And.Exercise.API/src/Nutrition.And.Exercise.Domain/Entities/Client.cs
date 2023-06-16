using Nutrition.And.Exercise.Core.Data;
using Nutrition.And.Exercise.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.And.Exercise.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public Client()
        {
        }

        public Client( Guid id, string nome, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
