using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Delete
{
    [Route(Endpoints.ApiPageDelete)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageDeleteController : ApiController<PageDeleteRequest>
    {
        public PageDeleteController(IApiRequestHandler<PageDeleteRequest> handler, IValidator<PageDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
