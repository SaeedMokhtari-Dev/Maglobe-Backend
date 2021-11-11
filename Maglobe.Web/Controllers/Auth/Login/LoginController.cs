using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.Login
{
    [Route(Endpoints.ApiAuthLogin)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class LoginController : ApiController<LoginRequest>
    {
        public LoginController(IApiRequestHandler<LoginRequest> handler, IValidator<LoginRequest> validator) : base(handler, validator)
        {
        }
    }
}
