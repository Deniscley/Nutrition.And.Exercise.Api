using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Domain.Interfaces.Queries
{
    public interface IClientQueries
    {
        Task<IEnumerable<ClientResponse>> GetCustomers();
        Task<ClientResponse> GetClient(Guid id);
    }
}
