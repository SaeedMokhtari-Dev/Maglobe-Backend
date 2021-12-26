using System;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Products : PageModel
    {
        private readonly MenuService _menuService;
        private readonly ProductService _productService;
        public Products(MenuService menuService, ProductService productService)
        {
            _menuService = menuService;
            _productService = productService;
        }
        public async Task OnGet(string siteLanguage)
        {
            Enum.TryParse(siteLanguage, out Language language);
            ViewData["Menus"] = await _menuService.GetActiveMenus(language);

            ViewData["Products"] = await _productService.GetActiveProducts(language);
        }
    }
}