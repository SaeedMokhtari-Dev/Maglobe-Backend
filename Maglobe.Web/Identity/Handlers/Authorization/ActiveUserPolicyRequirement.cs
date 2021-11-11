using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Identity.Handlers.Authorization
{
    public class ActiveUserPolicyRequirement : IAuthorizationRequirement
    {
        public bool IsActive { get; }

        public ActiveUserPolicyRequirement(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
