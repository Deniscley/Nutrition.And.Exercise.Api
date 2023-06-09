﻿using MediatR;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Application.CommandsHandler;
using Nutrition.And.Exercise.Application.Events;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using Nutrition.And.Exercise.Core.Mediator;
using Nutrition.And.Exercise.Data.Context;
using Nutrition.And.Exercise.Data.Repositories.EFRepositories;
using Nutrition.And.Exercise.Data.Repositories.DapperRepositories;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //// Repository
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientQueriesRepository, ClientQueriesRepository>();

            //// MediatorHandler
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //// CommandHandler
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

            //// Event
            services.AddScoped<INotificationHandler<RegisteredCustomerEvent>, ClientEventHandler>();

            //// Context
            services.AddScoped<DataContext>();
        }
    }
}
