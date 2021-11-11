using Maglobe.Core.Constants;
using Maglobe.Web.Configuration.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maglobe.Web.Initializers
{
    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedCorsOrigins = configuration.GetSection(SettingsKeys.AllowedCorsOrigins).Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(Policies.CorsPolicy, p =>
                {
                    p.WithOrigins(allowedCorsOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
