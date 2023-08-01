using Nutrition.And.Exercise.Data.MappingsProfile;

namespace Nutrition.And.Exercise.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ClientMappingProfile));
        }
    }
}
