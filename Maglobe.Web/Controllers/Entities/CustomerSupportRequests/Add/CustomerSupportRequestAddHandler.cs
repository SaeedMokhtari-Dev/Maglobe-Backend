using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Services;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Add
{
    public class CustomerSupportRequestAddHandler : ApiRequestHandler<CustomerSupportRequestAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CustomerSupportRequestAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CustomerSupportRequestAddRequest request)
        {
            CustomerSupportRequest customerSupportRequest = await AddCustomerSupportRequest(request);
            
            return ActionResult.Ok(ApiMessages.CustomerSupportRequestMessage.AddedSuccessfully);
        }
        
        private async Task<CustomerSupportRequest> AddCustomerSupportRequest(CustomerSupportRequestAddRequest request)
        {
            CustomerSupportRequest customerSupportRequest = await _context.ExecuteTransactionAsync(async () =>
            {
                CustomerSupportRequest newCustomerSupportRequest = _mapper.Map<CustomerSupportRequest>(request);

                newCustomerSupportRequest = (await _context.CustomerSupportRequests.AddAsync(newCustomerSupportRequest)).Entity;
                await _context.SaveChangesAsync();

                return newCustomerSupportRequest;
            });
            return customerSupportRequest;
        }
    }
}