using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Pages.Edit
{
    [Route(Endpoints.ApiDynamicPageEdit)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageEditController : ApiController<DynamicPageEditRequest>
    {
        public DynamicPageEditController(IApiRequestHandler<DynamicPageEditRequest> handler, IValidator<DynamicPageEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
