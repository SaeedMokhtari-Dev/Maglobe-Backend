using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Active
{
    [Route(Endpoints.ApiDynamicPageActive)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageActiveController : ApiController<DynamicPageActiveRequest>
    {
        public DynamicPageActiveController(IApiRequestHandler<DynamicPageActiveRequest> handler, IValidator<DynamicPageActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
