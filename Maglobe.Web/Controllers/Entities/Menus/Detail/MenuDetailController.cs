using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.Detail
{
    [Route(Endpoints.ApiMenuDetail)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize]
    public class MenuDetailController : ApiController<MenuDetailRequest>
    {
        public MenuDetailController(IApiRequestHandler<MenuDetailRequest> handler, IValidator<MenuDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
