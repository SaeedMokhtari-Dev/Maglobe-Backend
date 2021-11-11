using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Users.List
{
    [Route(Endpoints.ApiUserList)]
    [ApiExplorerSettings(GroupName = "User")]
    [Authorize]
    public class UserListController : ApiController<UserListRequest>
    {
        public UserListController(IApiRequestHandler<UserListRequest> handler, IValidator<UserListRequest> validator) : base(handler, validator)
        {
        }
    }
}
