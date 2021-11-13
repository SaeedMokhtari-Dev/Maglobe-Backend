using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Delete
{
    public class CustomerSupportRequestDeleteHandler : ApiRequestHandler<CustomerSupportRequestDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CustomerSupportRequestDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CustomerSupportRequestDeleteRequest request)
        {
            CustomerSupportRequest customerSupportRequest = await _context.CustomerSupportRequests
                .FindAsync(request.CustomerSupportRequestId);

            if (customerSupportRequest == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.CustomerSupportRequests.Remove(customerSupportRequest);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.CustomerSupportRequestMessage.DeletedSuccessfully);
        }
    }
}
