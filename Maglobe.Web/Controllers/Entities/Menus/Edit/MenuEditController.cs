using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.Edit
{
    [Route(Endpoints.ApiMenuEdit)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize]
    public class MenuEditController : ApiController<MenuEditRequest>
    {
        public MenuEditController(IApiRequestHandler<MenuEditRequest> handler, IValidator<MenuEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
