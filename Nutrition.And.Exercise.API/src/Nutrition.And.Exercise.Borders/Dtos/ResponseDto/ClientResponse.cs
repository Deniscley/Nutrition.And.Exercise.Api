namespace Nutrition.And.Exercise.Borders.Dtos.Response
{
    /// <summary>
    /// Object used to insert new customers.
    /// </summary>
    public class ClientResponse
    {
        /// <summary>
        /// Id of the client.
        /// </summary>
        /// <example>123</example>
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
    }
}
