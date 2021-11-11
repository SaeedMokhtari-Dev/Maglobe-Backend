using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.RefreshAccess
{
    [Route(Endpoints.ApiAuthRefreshAccessToken)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class RefreshAccessTokenController : ApiController<RefreshAccessTokenRequest>
    {
        public RefreshAccessTokenController(IApiRequestHandler<RefreshAccessTokenRequest> handler, IValidator<RefreshAccessTokenRequest> validator) : base(handler, validator)
        {
        }
    }
}
