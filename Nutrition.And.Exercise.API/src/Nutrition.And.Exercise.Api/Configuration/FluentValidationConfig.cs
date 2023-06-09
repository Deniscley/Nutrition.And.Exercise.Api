using FluentValidation.AspNetCore;
using System.Globalization;
using System.Text.Json.Serialization;
using static Nutrition.And.Exercise.Borders.Commands.RegisterClientCommand;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(x =>
                {
                    x.RegisterValidatorsFromAssemblyContaining<Startup>();
                    x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-Br");
                });

            //services.AddFluentValidationRulesToSwagger();
        }
    }
}
