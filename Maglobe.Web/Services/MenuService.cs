using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Services
{
    public class MenuService: ITransient
    {
        private readonly MaglobeContext _context;

        public MenuService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<List<MenuViewModel>> GetActiveMenus(Language language)
        {
            var query = _context.Menus
                .Where(w => w.IsActive && w.Language == language.ToString())
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            return await query.Select(w => new MenuViewModel()
            {
                Title = w.Title,
                Url = w.Url,
                DisplayOrder = w.DisplayOrder
            }) .ToListAsync();
        }
    }
}