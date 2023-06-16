using System.ComponentModel.DataAnnotations;

namespace Nutrition.And.Exercise.Domain.Dtos.Response
{
    /// <summary>
    /// Object used to insert new customers.
    /// </summary>
    public class ClientResponse : ICloneable
    {
        /// <summary>
        /// Id of the client.
        /// </summary>
        /// <example>123</example>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Client name.
        /// </summary>
        /// <example>João</example>
        public string Nome { get; set; }
        /// <summary>
        /// date of birth
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; set; }

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
