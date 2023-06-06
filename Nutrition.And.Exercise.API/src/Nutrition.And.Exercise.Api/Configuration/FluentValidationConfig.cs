using System.Text.Json.Serialization;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public class FluentValidationConfig
    {
        //public static void AddFluentValidationConfiguration(this IServiceCollection services)
        //{
        //    services.AddControllers()
        //        .AddNewtonsoftJson(x =>
        //        {
        //            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //            x.SerializerSettings.Converters.Add(new StringEnumConverter());
        //        })
        //        .AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
        //        .AddFluentValidation(p =>
        //        {
        //            p.RegisterValidatorsFromAssemblyContaining<RegisterClientValidation>();
        //            p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
        //        });

        //    services.AddFluentValidationRulesToSwagger();
        //}
    }
}
