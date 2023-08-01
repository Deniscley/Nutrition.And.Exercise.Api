using Bogus;
using Nutrition.And.Exercise.Application.Commands;

namespace Nutrition.And.Exercise.FakeData.Commands
{
    public class RegisterClientCommandFaker : Faker<RegisterClientCommand>
    {
        public RegisterClientCommandFaker()
        {
            var id = new Faker().Random.Guid();
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Nome, f => f.Person.FullName);
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
        }
    }
}
