using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Context
{
    public class DataContext : DbContext
    {
        IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public DbSet<Client> Customers { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext()
        {
            //ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_NutritionAndExercise;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
