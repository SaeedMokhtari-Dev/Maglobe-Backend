using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Products.Edit
{
    [Route(Endpoints.ApiProductEdit)]
    [ApiExplorerSettings(GroupName = "Product")]
    [Authorize]
    public class ProductEditController : ApiController<ProductEditRequest>
    {
        public ProductEditController(IApiRequestHandler<ProductEditRequest> handler, IValidator<ProductEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
