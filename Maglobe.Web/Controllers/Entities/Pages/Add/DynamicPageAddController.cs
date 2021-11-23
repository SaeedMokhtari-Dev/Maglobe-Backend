using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Add
{
    [Route(Endpoints.ApiDynamicPageAdd)]
    [ApiExplorerSettings(GroupName = "DynamicPage")]
    [Authorize]
    public class DynamicPageAddController : ApiController<DynamicPageAddRequest>
    {
        public DynamicPageAddController(IApiRequestHandler<DynamicPageAddRequest> handler, IValidator<DynamicPageAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
