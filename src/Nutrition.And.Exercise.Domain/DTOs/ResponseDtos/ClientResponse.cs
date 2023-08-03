using System.ComponentModel.DataAnnotations;

namespace Nutrition.And.Exercise.Domain.DTOs.ResponseDtos
{
    /// <summary>
    /// Object used to insert new client.
    /// </summary>
    public class ClientResponse : ICloneable
    {
        /// <summary>
        /// Id of the client.
        /// </summary>
        /// <example>123</example>
        [Required]
        public Guid Id { get; private set; }

        /// <summary>
        /// Client name.
        /// </summary>
        /// <example>João</example>
        public string Nome { get; private set; }

        /// <summary>
        /// date of birth
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; private set; }

        /// <summary>
        /// Client cpf.
        /// </summary>
        /// <example>19873648725</example>
        public string Cpf { get; private set; }

        public object Clone()
        {
            var client = (ClientResponse)MemberwiseClone();
            return client;
        }

        public ClientResponse TypedClone()
        {
            return (ClientResponse)Clone();
        }
    }
}
