﻿namespace Nutrition.And.Exercise.Domain.DTOs.RequestDtos
{
    /// <summary>
    /// Object used to insert new customers.
    /// </summary>
    public class ClientRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
