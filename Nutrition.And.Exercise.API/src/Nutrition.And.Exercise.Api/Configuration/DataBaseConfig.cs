using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Data.Context;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
