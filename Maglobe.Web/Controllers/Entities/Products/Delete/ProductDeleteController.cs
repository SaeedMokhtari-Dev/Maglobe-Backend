using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.Delete
{
    [Route(Endpoints.ApiProductDelete)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductDeleteController : ApiController<ProductDeleteRequest>
    {
        public ProductDeleteController(IApiRequestHandler<ProductDeleteRequest> handler, IValidator<ProductDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
