using Bogus;
using Nutrition.And.Exercise.Domain.Entities;

namespace Nutrition.And.Exercise.FakeData.Entities
{
    public class ClientFaker : Faker<Client>
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
