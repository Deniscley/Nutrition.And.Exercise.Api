using FluentValidation;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => 
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //services.AddFluentValidationRulesToSwagger();
        }
    }
}
