using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.ValidateResetPasswordToken
{
    [Route(Endpoints.ApiAuthValidateResetPasswordToken)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ValidateResetPasswordTokenController : ApiController<ValidateResetPasswordTokenRequest>
    {
        public ValidateResetPasswordTokenController(IApiRequestHandler<ValidateResetPasswordTokenRequest> handler, IValidator<ValidateResetPasswordTokenRequest> validator) : base(handler, validator)
        {
        }
    }
}
