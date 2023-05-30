using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Borders.Interfaces.UseCases
{
    public interface IClientUseCase
    {
        Task<Client> GetClientAsync(int id);
        Task<IEnumerable<Client>> GetCustomersAsync();
    }
}
