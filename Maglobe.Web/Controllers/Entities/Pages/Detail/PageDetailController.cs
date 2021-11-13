using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Detail
{
    [Route(Endpoints.ApiPageDetail)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageDetailController : ApiController<PageDetailRequest>
    {
        public PageDetailController(IApiRequestHandler<PageDetailRequest> handler, IValidator<PageDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
