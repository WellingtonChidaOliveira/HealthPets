namespace HealthPets.Api.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static IServiceCollection ConfigureCoresPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
    }
}
