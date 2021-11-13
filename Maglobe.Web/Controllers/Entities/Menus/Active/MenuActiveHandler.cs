using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Menus.Active
{
    public class MenuActiveHandler : ApiRequestHandler<MenuActiveRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public MenuActiveHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuActiveRequest request)
        {
            Menu menu = await _context.Menus
                .FindAsync(request.MenuId);

            if (menu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            menu.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.MenuMessage.ActivatedSuccessfully);
        }
    }
}
