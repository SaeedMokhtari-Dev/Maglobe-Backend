using System;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Pages.Components
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly MenuService _menuService;
        public MenuViewComponent(MenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<IViewComponentResult> InvokeAsync(
            string siteLanguage)
        {
            Enum.TryParse(siteLanguage, out Language language);
            var menus = await _menuService.GetActiveMenus(language);
            return View(menus);
        }
    }
}