using Maglobe.Core.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Identity.Handlers.Authorization
{
    public static class AuthorizationPolicyExtensions
    {
        public static AuthorizationOptions RequireActiveUser(this AuthorizationOptions options)
        {
            options.AddPolicy(nameof(Policies.ActiveUser), x => x.Requirements.Add(new ActiveUserPolicyRequirement(true)));

            return options;
        }
    }
}
