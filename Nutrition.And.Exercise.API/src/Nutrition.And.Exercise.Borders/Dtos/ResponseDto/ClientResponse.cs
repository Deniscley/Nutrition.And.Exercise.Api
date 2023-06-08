using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Id { get; set; }
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
