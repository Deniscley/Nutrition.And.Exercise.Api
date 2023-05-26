using Nutrition.And.Exercise.Api.Configuration;

namespace Nutrition.And.Exercise.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //// Add services to the container.
            services.AddControllers();

            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddDatabaseConfiguration(Configuration);
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwaggerConfiguration();
        }
    }
}
