using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.Get
{
    [Route(Endpoints.ApiMenuGet)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize]
    public class MenuGetController : ApiController<MenuGetRequest>
    {
        public MenuGetController(IApiRequestHandler<MenuGetRequest> handler, IValidator<MenuGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
