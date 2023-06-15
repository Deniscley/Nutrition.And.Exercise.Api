using Bogus;
using Nutrition.And.Exercise.Domain.Dtos.Response;
using Nutrition.And.Exercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.FakeData.ClientData
{
    public class ClientFaker : Faker<ClientResponse>
    {
        public ClientFaker()
        {
            var id = new Faker().Random.Guid();
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Nome, f => f.Person.FullName);
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
        }
    }
}
