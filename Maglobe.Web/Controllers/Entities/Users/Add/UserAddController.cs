using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.Add
{
    [Route(Endpoints.ApiUserAdd)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserAddController : ApiController<UserAddRequest>
    {
        public UserAddController(IApiRequestHandler<UserAddRequest> handler, IValidator<UserAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
