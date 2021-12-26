using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Menus.Add
{
    public class MenuAddHandler : ApiRequestHandler<MenuAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        
        public MenuAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuAddRequest request)
        {
            Menu menu = await AddMenu(request);
            
            return ActionResult.Ok(ApiMessages.MenuMessage.AddedSuccessfully);
        }
        
        private async Task<Menu> AddMenu(MenuAddRequest request)
        {
            Menu menu = await _context.ExecuteTransactionAsync(async () =>
            {
                Menu newMenu = _mapper.Map<Menu>(request);

                newMenu = (await _context.Menus.AddAsync(newMenu)).Entity;
                await _context.SaveChangesAsync();

                return newMenu;
            });
            return menu;
        }
    }
}