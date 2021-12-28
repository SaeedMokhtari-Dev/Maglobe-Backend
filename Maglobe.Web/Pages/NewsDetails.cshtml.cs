using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages
{
    public class NewsDetails : BasePageModel
    {
        private readonly BlogService _blogService;
        public NewsDetails(BlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task OnGet(int newsId, string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            
            ViewData["News"] = await _blogService.GetBlogDetail(language, newsId);
            ViewData["BodyClass"] = "news-detail";
        }
    }
}