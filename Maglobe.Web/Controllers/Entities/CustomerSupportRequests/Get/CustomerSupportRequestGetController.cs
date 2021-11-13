using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Get
{
    [Route(Endpoints.ApiCustomerSupportRequestGet)]
    [ApiExplorerSettings(GroupName = "CustomerSupportRequest")]
    [Authorize]
    public class CustomerSupportRequestGetController : ApiController<CustomerSupportRequestGetRequest>
    {
        public CustomerSupportRequestGetController(IApiRequestHandler<CustomerSupportRequestGetRequest> handler, IValidator<CustomerSupportRequestGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
