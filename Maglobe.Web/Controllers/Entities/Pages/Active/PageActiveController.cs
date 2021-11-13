using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Active
{
    [Route(Endpoints.ApiPageActive)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageActiveController : ApiController<PageActiveRequest>
    {
        public PageActiveController(IApiRequestHandler<PageActiveRequest> handler, IValidator<PageActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
