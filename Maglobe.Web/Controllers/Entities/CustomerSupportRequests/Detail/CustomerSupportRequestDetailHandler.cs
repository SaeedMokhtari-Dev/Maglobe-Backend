using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Detail
{
    public class CustomerSupportRequestDetailHandler : ApiRequestHandler<CustomerSupportRequestDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CustomerSupportRequestDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CustomerSupportRequestDetailRequest request)
        {
            CustomerSupportRequest customerSupportRequest = await _context.CustomerSupportRequests
                .FirstOrDefaultAsync(w => w.Id == request.CustomerSupportRequestId);

            if (customerSupportRequest == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            CustomerSupportRequestDetailResponse response = _mapper.Map<CustomerSupportRequestDetailResponse>(customerSupportRequest);
            
            return ActionResult.Ok(response);
        }
    }
}
