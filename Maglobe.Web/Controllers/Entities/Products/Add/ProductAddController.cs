using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.Add
{
    [Route(Endpoints.ApiProductAdd)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductAddController : ApiController<ProductAddRequest>
    {
        public ProductAddController(IApiRequestHandler<ProductAddRequest> handler, IValidator<ProductAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
