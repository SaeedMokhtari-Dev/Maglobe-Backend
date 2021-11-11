using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.ChangePassword
{
    [Route(Endpoints.ApiAuthChangePassword)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ChangePasswordController : ApiController<ChangePasswordRequest>
    {
        public ChangePasswordController(IApiRequestHandler<ChangePasswordRequest> handler, IValidator<ChangePasswordRequest> validator) : base(handler, validator)
        {
        }
    }
}
