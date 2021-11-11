using Maglobe.Web.Identity.Constants;
using Maglobe.Web.Identity.Handlers.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Maglobe.Web.Initializers
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options
                    .RequireActiveUser()
                    .DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(AuthSchemes.Jwt)
                    .Build();
            });

            services.AddScoped<IAuthorizationHandler, ActiveUserAuthorizationHandler>();

            return services;
        }
    }
}
