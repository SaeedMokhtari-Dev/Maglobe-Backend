using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.Logout
{
    [Route(Endpoints.ApiAuthLogout)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class LogoutController : ApiController<LogoutRequest>
    {
        public LogoutController(IApiRequestHandler<LogoutRequest> handler, IValidator<LogoutRequest> validator) : base(handler, validator)
        {
        }
    }
}
