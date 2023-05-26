using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Repositories.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
