using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Add
{
    [Route(Endpoints.ApiPageAdd)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageAddController : ApiController<PageAddRequest>
    {
        public PageAddController(IApiRequestHandler<PageAddRequest> handler, IValidator<PageAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
