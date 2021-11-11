using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.Edit
{
    [Route(Endpoints.ApiUserEdit)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserEditController : ApiController<UserEditRequest>
    {
        public UserEditController(IApiRequestHandler<UserEditRequest> handler, IValidator<UserEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
