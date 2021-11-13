using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.Get
{
    public class PageGetHandler : ApiRequestHandler<PageGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageGetRequest request)
        {
            var query = _context.Pages.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PageGetResponseItem>>(result);

            PageGetResponse response = new PageGetResponse();
            response.TotalCount = await _context.Pages.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
