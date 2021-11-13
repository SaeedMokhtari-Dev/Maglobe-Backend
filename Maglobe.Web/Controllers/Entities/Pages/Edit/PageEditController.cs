using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Edit
{
    [Route(Endpoints.ApiPageEdit)]
    [ApiExplorerSettings(GroupName = "Page")]
    [Authorize]
    public class PageEditController : ApiController<PageEditRequest>
    {
        public PageEditController(IApiRequestHandler<PageEditRequest> handler, IValidator<PageEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
