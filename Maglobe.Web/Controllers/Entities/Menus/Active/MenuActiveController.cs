using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.Active
{
    [Route(Endpoints.ApiMenuActive)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize]
    public class MenuActiveController : ApiController<MenuActiveRequest>
    {
        public MenuActiveController(IApiRequestHandler<MenuActiveRequest> handler, IValidator<MenuActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
