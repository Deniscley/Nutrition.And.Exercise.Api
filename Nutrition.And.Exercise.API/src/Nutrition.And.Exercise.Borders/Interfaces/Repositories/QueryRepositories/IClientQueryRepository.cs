using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Borders.Interfaces.Repositories.QueryRepositories
{
    public interface IClientQueryRepository
    {
        Task InsertCustomer(Client client);
        //Task<IEnumerable<Client>> GetCustomersAsync();
        Task<Client?> GetClientAsync(Guid id);

    }
}
