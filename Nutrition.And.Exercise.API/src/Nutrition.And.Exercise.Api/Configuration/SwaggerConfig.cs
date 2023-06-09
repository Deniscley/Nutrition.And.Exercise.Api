using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo 
                    { Title = "Nutrition & Exercise",
                      Version = "v1",
                      Description = "API of the Nutrition & Exercise application.",
                      Contact = new Microsoft.OpenApi.Models.OpenApiContact
                      {
                          Name = "Deniscley Marfran",
                          Email = "deniscleymaf@outlook.com",
                          Url = new Uri("https://github.com/Deniscley")
                      },
                      License = new Microsoft.OpenApi.Models.OpenApiLicense
                      {
                          Name = "OSD",
                          Url = new Uri("https://opensource.org/osd")
                      },
                      TermsOfService = new Uri("https://opensource.org/osd")
                    });

                c.AddFluentValidationRulesScoped();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile) ;
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "Nutrition.And.Exercise.Borders.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "Nutrition & Exercise v1");
                });
            }
        }
    }
}
