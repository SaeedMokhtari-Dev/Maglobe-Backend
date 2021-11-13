using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Menus.Add
{
    [Route(Endpoints.ApiMenuAdd)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize]
    public class MenuAddController : ApiController<MenuAddRequest>
    {
        public MenuAddController(IApiRequestHandler<MenuAddRequest> handler, IValidator<MenuAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
