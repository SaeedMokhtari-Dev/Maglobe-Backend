using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.List
{
    public class PageListHandler : ApiRequestHandler<PageListRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageListHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageListRequest request)
        {
            var query = _context.Pages
                .OrderByDescending(w => w.Id)
                .AsQueryable();

            var response = await query.Select(w =>
            new PageListResponseItem() {
                Key = w.Id, 
                Title = w.Title,
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
