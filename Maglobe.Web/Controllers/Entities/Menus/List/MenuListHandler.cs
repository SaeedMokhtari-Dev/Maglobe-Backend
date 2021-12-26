using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Menus.List
{
    public class MenuListHandler : ApiRequestHandler<MenuListRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public MenuListHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuListRequest request)
        {
            var query = _context.Menus
                .OrderByDescending(w => w.Id)
                .AsQueryable();

            var response = await query.Select(w =>
            new MenuListResponseItem() {
                Key = w.Id, 
                Title = w.Title,
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
