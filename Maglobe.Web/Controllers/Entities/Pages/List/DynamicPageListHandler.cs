using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.List
{
    public class DynamicPageListHandler : ApiRequestHandler<DynamicPageListRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public DynamicPageListHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(DynamicPageListRequest request)
        {
            var query = _context.DynamicPages
                .OrderByDescending(w => w.Id)
                .AsQueryable();

            var response = await query.Select(w =>
            new DynamicPageListResponseItem() {
                Key = w.Id, 
                Title = w.Title,
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
