using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
using static Nutrition.And.Exercise.Borders.Commands.RegisterClientCommand;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<RegisterClientValidation>();
                    p.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");
                });

            //services.AddFluentValidationRulesToSwagger();
        }
    }
}
