using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Menus.Delete
{
    public class MenuDeleteHandler : ApiRequestHandler<MenuDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public MenuDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuDeleteRequest request)
        {
            Menu menu = await _context.Menus
                .FindAsync(request.MenuId);

            if (menu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.MenuMessage.DeletedSuccessfully);
        }
    }
}
