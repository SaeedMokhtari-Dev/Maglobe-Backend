using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.Detail
{
    [Route(Endpoints.ApiUserDetail)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserDetailController : ApiController<UserDetailRequest>
    {
        public UserDetailController(IApiRequestHandler<UserDetailRequest> handler, IValidator<UserDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
