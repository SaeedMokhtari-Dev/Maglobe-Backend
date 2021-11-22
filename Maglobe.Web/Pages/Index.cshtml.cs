using System;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Index : PageModel
    {
        private readonly MenuService _menuService; 
        public Index(MenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task OnGet(string siteLanguage)
        {
            Enum.TryParse(siteLanguage, out Language language);
            ViewData["Menus"] = await _menuService.GetActiveMenus(language);
        }
    }
}