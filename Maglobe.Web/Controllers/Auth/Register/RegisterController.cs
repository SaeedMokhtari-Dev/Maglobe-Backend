using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.Register
{
    [Route(Endpoints.ApiAuthRegister)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class RegisterController : ApiController<RegisterRequest>
    {
        public RegisterController(IApiRequestHandler<RegisterRequest> handler, IValidator<RegisterRequest> validator) : base(handler, validator)
        {
        }
    }
}
