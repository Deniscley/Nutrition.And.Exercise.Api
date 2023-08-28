using MediatR;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Application.CommandsHandler;
using Nutrition.And.Exercise.Application.Events;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using Nutrition.And.Exercise.Data.Context;
using Nutrition.And.Exercise.Data.Repositories.EFRepositories;
using Nutrition.And.Exercise.Data.Repositories.DapperRepositories;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Nutrition.And.Exercise.Core.Communication.Mediator;
using Nutrition.And.Exercise.Core.Messages.CommonMessages.Notifications;
using Nutrition.And.Exercise.Application.EventsHandlers;
using Nutrition.And.Exercise.Domain.Interfaces.Queries;
using Nutrition.And.Exercise.Application.Queries;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.MongoDBRepositories;
using Nutrition.And.Exercise.Data.Repositories.MongoDBRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.MongoDBServices;
using Nutrition.And.Exercise.Application.MongoDBServices;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Mediator

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // Repository
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientQueriesRepository, ClientQueriesRepository>();
            services.AddScoped<IProductMongoRepository, ProductMongoRepository>();

            // MediatorHandler
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // CommandHandler
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

            // Queries
            services.AddScoped<IClientQueries, ClientQueries>();

            //MongoDBServices
            services.AddScoped<IProductAppServices, ProductAppServices>();

            //

            // Event
            services.AddScoped<INotificationHandler<RegisteredCustomerEvent>, ClientEventHandler>();

            // Context
            services.AddScoped<DataContext>();
        }
    }
}
