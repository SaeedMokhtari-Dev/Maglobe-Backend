using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.Active
{
    [Route(Endpoints.ApiProductActive)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductActiveController : ApiController<ProductActiveRequest>
    {
        public ProductActiveController(IApiRequestHandler<ProductActiveRequest> handler, IValidator<ProductActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
