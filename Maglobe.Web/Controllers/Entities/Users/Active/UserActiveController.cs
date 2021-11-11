using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.Active
{
    [Route(Endpoints.ApiUserActive)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserActiveController : ApiController<UserActiveRequest>
    {
        public UserActiveController(IApiRequestHandler<UserActiveRequest> handler, IValidator<UserActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
