using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Delete
{
    [Route(Endpoints.ApiDynamicPageDelete)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageDeleteController : ApiController<DynamicPageDeleteRequest>
    {
        public DynamicPageDeleteController(IApiRequestHandler<DynamicPageDeleteRequest> handler, IValidator<DynamicPageDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
