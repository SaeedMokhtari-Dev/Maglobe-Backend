using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.ChangeUserPassword
{
    [Route(Endpoints.ApiAuthChangeUserPassword)]
    [ApiExplorerSettings(GroupName = "Auth")]
    [Authorize]
    public class ChangeUserPasswordController : ApiController<ChangeUserPasswordRequest>
    {
        public ChangeUserPasswordController(IApiRequestHandler<ChangeUserPasswordRequest> handler, IValidator<ChangeUserPasswordRequest> validator) : base(handler, validator)
        {
        }
    }
}
