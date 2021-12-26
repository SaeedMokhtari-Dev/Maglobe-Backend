using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Menus.Detail
{
    public class MenuDetailHandler : ApiRequestHandler<MenuDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public MenuDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuDetailRequest request)
        {
            Menu menu = await _context.Menus
                .FirstOrDefaultAsync(w => w.Id == request.MenuId);

            if (menu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            MenuDetailResponse response = _mapper.Map<MenuDetailResponse>(menu);
            
            return ActionResult.Ok(response);
        }
    }
}
