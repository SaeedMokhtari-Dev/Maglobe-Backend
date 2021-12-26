using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Edit
{
    public class CustomerSupportRequestEditHandler : ApiRequestHandler<CustomerSupportRequestEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CustomerSupportRequestEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CustomerSupportRequestEditRequest request)
        {
            CustomerSupportRequest editCustomerSupportRequest = await _context.CustomerSupportRequests
                .FirstOrDefaultAsync(w => w.Id == request.CustomerSupportRequestId);

            if (editCustomerSupportRequest == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditCustomerSupportRequest(editCustomerSupportRequest, request);
            return ActionResult.Ok(ApiMessages.CustomerSupportRequestMessage.EditedSuccessfully);
        }

        private async Task EditCustomerSupportRequest(CustomerSupportRequest editCustomerSupportRequest, CustomerSupportRequestEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editCustomerSupportRequest);
                
                await _context.SaveChangesAsync();

                return editCustomerSupportRequest;
            });
        }
    }
}