using System;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Index : BasePageModel
    {
        private readonly MenuService _menuService; 
        public Index(MenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            ViewData["BodyClass"] = "saeed";
        }
    }
}