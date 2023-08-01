using Nutrition.And.Exercise.Core.Data;
using Nutrition.And.Exercise.Core.DomainObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.And.Exercise.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
        [Required]
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Client()
        {
        }

        public Client( Guid id, string nome, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;

            Validate();
        }

        public void InsertId( Guid id )
        {
            Id = id;
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Nome, "O campo Nome do cliente não pode estar vazio");
        }
    }
}
