namespace Nutrition.And.Exercise.Domain.DTOs.RequestDtos
{
    /// <summary>
    /// Object used to insert new customers.
    /// </summary>
    public class ClientRequest
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public string Cpf { get; private set; }
    }
}
