using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.Delete
{
    [Route(Endpoints.ApiMenuDelete)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize]
    public class MenuDeleteController : ApiController<MenuDeleteRequest>
    {
        public MenuDeleteController(IApiRequestHandler<MenuDeleteRequest> handler, IValidator<MenuDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
