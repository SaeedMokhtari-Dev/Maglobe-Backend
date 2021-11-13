using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Edit
{
    [Route(Endpoints.ApiCustomerSupportRequestEdit)]
    [ApiExplorerSettings(GroupName = "CustomerSupportRequest")]
    [Authorize]
    public class CustomerSupportRequestEditController : ApiController<CustomerSupportRequestEditRequest>
    {
        public CustomerSupportRequestEditController(IApiRequestHandler<CustomerSupportRequestEditRequest> handler, IValidator<CustomerSupportRequestEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
