using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Detail
{
    [Route(Endpoints.ApiDynamicPageDetail)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageDetailController : ApiController<DynamicPageDetailRequest>
    {
        public DynamicPageDetailController(IApiRequestHandler<DynamicPageDetailRequest> handler, IValidator<DynamicPageDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
