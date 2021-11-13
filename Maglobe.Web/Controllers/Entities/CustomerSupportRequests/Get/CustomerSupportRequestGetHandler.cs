using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Get
{
    public class CustomerSupportRequestGetHandler : ApiRequestHandler<CustomerSupportRequestGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CustomerSupportRequestGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CustomerSupportRequestGetRequest request)
        {
            var query = _context.CustomerSupportRequests.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CustomerSupportRequestGetResponseItem>>(result);

            CustomerSupportRequestGetResponse response = new CustomerSupportRequestGetResponse();
            response.TotalCount = await _context.CustomerSupportRequests.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
