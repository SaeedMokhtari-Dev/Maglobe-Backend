using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.Delete
{
    [Route(Endpoints.ApiUserDelete)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserDeleteController : ApiController<UserDeleteRequest>
    {
        public UserDeleteController(IApiRequestHandler<UserDeleteRequest> handler, IValidator<UserDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
