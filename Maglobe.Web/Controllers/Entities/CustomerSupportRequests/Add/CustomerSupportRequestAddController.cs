using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Add
{
    [Route(Endpoints.ApiCustomerSupportRequestAdd)]
    [ApiExplorerSettings(GroupName = "CustomerSupportRequest")]
    [Authorize]
    public class CustomerSupportRequestAddController : ApiController<CustomerSupportRequestAddRequest>
    {
        public CustomerSupportRequestAddController(IApiRequestHandler<CustomerSupportRequestAddRequest> handler, IValidator<CustomerSupportRequestAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
