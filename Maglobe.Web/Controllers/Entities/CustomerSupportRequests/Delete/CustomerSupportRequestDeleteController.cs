using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Delete
{
    [Route(Endpoints.ApiCustomerSupportRequestDelete)]
    [ApiExplorerSettings(GroupName = "CustomerSupportRequest")]
    [Authorize]
    public class CustomerSupportRequestDeleteController : ApiController<CustomerSupportRequestDeleteRequest>
    {
        public CustomerSupportRequestDeleteController(IApiRequestHandler<CustomerSupportRequestDeleteRequest> handler, IValidator<CustomerSupportRequestDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
