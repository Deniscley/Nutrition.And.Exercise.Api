using FluentValidation;
using FluentValidation.AspNetCore;
using Nutrition.And.Exercise.Borders.Commands;
using System;
using System.Globalization;
using System.Text.Json.Serialization;
using static Nutrition.And.Exercise.Borders.Commands.RegisterClientCommand;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            //services.AddFluentValidationRulesToSwagger();
        }
    }
}
