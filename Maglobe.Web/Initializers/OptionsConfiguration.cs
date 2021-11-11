using Maglobe.Web.Configuration.Constants;
using Maglobe.Web.Configuration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maglobe.Web.Initializers
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BCryptOptions>(configuration.GetSection(SettingsKeys.BCrypt));
            services.Configure<SmtpOptions>(configuration.GetSection(SettingsKeys.Smtp));

            return services;
        }
    }
}
