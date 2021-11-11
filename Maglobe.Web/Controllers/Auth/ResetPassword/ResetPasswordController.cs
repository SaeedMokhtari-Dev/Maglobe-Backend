using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.ResetPassword
{
    [Route(Endpoints.ApiAuthResetPassword)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ResetPasswordController : ApiController<ResetPasswordRequest>
    {
        public ResetPasswordController(IApiRequestHandler<ResetPasswordRequest> handler, IValidator<ResetPasswordRequest> validator) : base(handler, validator)
        {
        }
    }
}
