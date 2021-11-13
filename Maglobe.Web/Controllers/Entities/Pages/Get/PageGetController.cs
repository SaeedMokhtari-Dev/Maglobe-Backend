using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Get
{
    [Route(Endpoints.ApiPageGet)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageGetController : ApiController<PageGetRequest>
    {
        public PageGetController(IApiRequestHandler<PageGetRequest> handler, IValidator<PageGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
