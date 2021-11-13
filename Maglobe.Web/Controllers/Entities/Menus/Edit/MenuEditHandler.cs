using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Contexts;
using Maglobe.Web.Identity.Services;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Menus.Edit
{
    public class MenuEditHandler : ApiRequestHandler<MenuEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public MenuEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(MenuEditRequest request)
        {
            Menu editMenu = await _context.Menus
                .FirstOrDefaultAsync(w => w.Id == request.MenuId);

            if (editMenu == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditMenu(editMenu, request);
            return ActionResult.Ok(ApiMessages.MenuMessage.EditedSuccessfully);
        }

        private async Task EditMenu(Menu editMenu, MenuEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editMenu);
                
                await _context.SaveChangesAsync();

                return editMenu;
            });
        }
    }
}