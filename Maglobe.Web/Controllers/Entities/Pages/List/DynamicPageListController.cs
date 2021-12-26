using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.List
{
    [Route(Endpoints.ApiDynamicPageList)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageListController : ApiController<DynamicPageListRequest>
    {
        public DynamicPageListController(IApiRequestHandler<DynamicPageListRequest> handler, IValidator<DynamicPageListRequest> validator) : base(handler, validator)
        {
        }
    }
}
