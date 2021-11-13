using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.Detail
{
    [Route(Endpoints.ApiProductDetail)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductDetailController : ApiController<ProductDetailRequest>
    {
        public ProductDetailController(IApiRequestHandler<ProductDetailRequest> handler, IValidator<ProductDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
