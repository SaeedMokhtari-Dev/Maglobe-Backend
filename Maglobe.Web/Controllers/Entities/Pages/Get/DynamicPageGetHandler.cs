using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Get
{
    public class DynamicPageGetHandler : ApiRequestHandler<DynamicPageGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public DynamicPageGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(DynamicPageGetRequest request)
        {
            var query = _context.DynamicPages.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<DynamicPageGetResponseItem>>(result);

            DynamicPageGetResponse response = new DynamicPageGetResponse();
            response.TotalCount = await _context.DynamicPages.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
