using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Get
{
    [Route(Endpoints.ApiDynamicPageGet)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageGetController : ApiController<DynamicPageGetRequest>
    {
        public DynamicPageGetController(IApiRequestHandler<DynamicPageGetRequest> handler, IValidator<DynamicPageGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
