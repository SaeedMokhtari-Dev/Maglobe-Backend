using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.List
{
    [Route(Endpoints.ApiMenuList)]
    [ApiExplorerSettings(GroupName = "Menu")]
    public class MenuListController : ApiController<MenuListRequest>
    {
        public MenuListController(IApiRequestHandler<MenuListRequest> handler, IValidator<MenuListRequest> validator) : base(handler, validator)
        {
        }
    }
}
