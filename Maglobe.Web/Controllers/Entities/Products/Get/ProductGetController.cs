using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.Get
{
    [Route(Endpoints.ApiProductGet)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductGetController : ApiController<ProductGetRequest>
    {
        public ProductGetController(IApiRequestHandler<ProductGetRequest> handler, IValidator<ProductGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
