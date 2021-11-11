using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.Get
{
    [Route(Endpoints.ApiUserGet)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserGetController : ApiController<UserGetRequest>
    {
        public UserGetController(IApiRequestHandler<UserGetRequest> handler, IValidator<UserGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
