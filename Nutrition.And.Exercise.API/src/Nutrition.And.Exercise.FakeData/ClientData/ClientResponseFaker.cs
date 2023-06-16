using Bogus;
using Nutrition.And.Exercise.Domain.Dtos.Response;

namespace Nutrition.And.Exercise.FakeData.ClientData
{
    public class ClientResponseFaker : Faker<ClientResponse>
    {
        public ClientResponseFaker()
        {
            var id = new Faker().Random.Guid();
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Nome, f => f.Person.FullName);
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
        }
    }
}
