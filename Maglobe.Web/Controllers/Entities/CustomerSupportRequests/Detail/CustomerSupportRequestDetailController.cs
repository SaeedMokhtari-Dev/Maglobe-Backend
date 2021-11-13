using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Detail
{
    [Route(Endpoints.ApiCustomerSupportRequestDetail)]
    [ApiExplorerSettings(GroupName = "CustomerSupportRequest")]
    [Authorize]
    public class CustomerSupportRequestDetailController : ApiController<CustomerSupportRequestDetailRequest>
    {
        public CustomerSupportRequestDetailController(IApiRequestHandler<CustomerSupportRequestDetailRequest> handler, IValidator<CustomerSupportRequestDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
