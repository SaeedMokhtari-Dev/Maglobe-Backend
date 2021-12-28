using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages
{
    public class DynamicPages : BasePageModel
    {
        private readonly DynamicPageService _dynamicPageService;

        public DynamicPages(DynamicPageService dynamicPageService)
        {
            _dynamicPageService = dynamicPageService;
        }

        public async Task OnGet(int dynamicPageId, string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            
            ViewData["DynamicPage"] = await _dynamicPageService.GetDynamicPage(language, dynamicPageId);
            ViewData["BodyClass"] = "news-detail";
        }
    }
}