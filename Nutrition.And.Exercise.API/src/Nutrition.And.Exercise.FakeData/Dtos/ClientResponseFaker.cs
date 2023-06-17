using Bogus;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;

namespace Nutrition.And.Exercise.FakeData.Dtos
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
