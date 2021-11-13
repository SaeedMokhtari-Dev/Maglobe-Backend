using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.List
{
    [Route(Endpoints.ApiProductList)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductListController : ApiController<ProductListRequest>
    {
        public ProductListController(IApiRequestHandler<ProductListRequest> handler, IValidator<ProductListRequest> validator) : base(handler, validator)
        {
        }
    }
}
