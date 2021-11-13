using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.List
{
    [Route(Endpoints.ApiPageList)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageListController : ApiController<PageListRequest>
    {
        public PageListController(IApiRequestHandler<PageListRequest> handler, IValidator<PageListRequest> validator) : base(handler, validator)
        {
        }
    }
}
