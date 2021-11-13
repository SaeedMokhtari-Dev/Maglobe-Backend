using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Menus.Get
{
    public class MenuGetHandler : ApiRequestHandler<MenuGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public MenuGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuGetRequest request)
        {
            var query = _context.Menus.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<MenuGetResponseItem>>(result);

            MenuGetResponse response = new MenuGetResponse();
            response.TotalCount = await _context.Menus.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
