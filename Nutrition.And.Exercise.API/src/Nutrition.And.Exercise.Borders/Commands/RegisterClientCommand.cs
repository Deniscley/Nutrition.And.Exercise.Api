using Nutrition.And.Exercise.Borders.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Borders.Commands
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
    }
}
