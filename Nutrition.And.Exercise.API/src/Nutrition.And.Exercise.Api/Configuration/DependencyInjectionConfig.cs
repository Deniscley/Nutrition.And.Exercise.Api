using MediatR;
using Nutrition.And.Exercise.Borders.Commands;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.QueryRepositories;
using Nutrition.And.Exercise.Borders.Interfaces.UseCases;
using Nutrition.And.Exercise.Borders.Mediator;
using Nutrition.And.Exercise.Data.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Data.Repositories.QueryRepositories;
using Nutrition.And.Exercise.UseCases;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //// Repository
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientQueryRepository, ClientQueryRepository>();

            //// UseCase
            services.AddScoped<IClientUseCase, ClientUseCase>();

            //// MediatorHandler
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            ///CommandHandler
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();
        }
    }
}
