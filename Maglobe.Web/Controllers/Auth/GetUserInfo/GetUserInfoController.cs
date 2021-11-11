using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Constants;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.GetUserInfo
{
    [Authorize(Policy = nameof(Policies.ActiveUser))]
    [Route(Endpoints.ApiUserInfo)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class GetUserInfoController : ApiController<GetUserInfoRequest>
    {
        public GetUserInfoController(IApiRequestHandler<GetUserInfoRequest> handler, IValidator<GetUserInfoRequest> validator) : base(handler, validator)
        {
        }
    }
}
