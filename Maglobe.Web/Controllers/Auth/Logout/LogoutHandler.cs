using System.Threading.Tasks;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Web.Identity.Contexts;
using Maglobe.Web.Identity.Services;

namespace Maglobe.Web.Controllers.Auth.Logout
{
    public class LogoutHandler : ApiRequestHandler<LogoutRequest>
    {
        private readonly UserContext _userContext;
        private readonly RefreshTokenService _refreshTokenService;

        public LogoutHandler(UserContext userContext, RefreshTokenService refreshTokenService)
        {
            _userContext = userContext;
            _refreshTokenService = refreshTokenService;
        }

        protected override async Task<ActionResult> Execute(LogoutRequest request)
        {
            if (_userContext.IsAuthenticated)
            {
                await _refreshTokenService.DeactivateToken(request.Token, _userContext.Id);
            }

            return ActionResult.Ok();
        }
    }
}
