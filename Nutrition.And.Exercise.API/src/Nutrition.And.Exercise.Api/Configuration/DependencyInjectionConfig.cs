using Nutrition.And.Exercise.Borders.Interfaces.Repository;
using Nutrition.And.Exercise.Borders.Interfaces.UseCases;
using Nutrition.And.Exercise.Data.Repository;
using Nutrition.And.Exercise.UseCases;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //// Repository
            services.AddScoped<IClientRepository, ClientRepository>();

            //// UseCase
            services.AddScoped<IClientUseCase, ClientUseCase>();
        }
    }
}
