using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class News : BasePageModel
    {
        private readonly BlogService _blogService;
        public News(BlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            
            ViewData["BodyClass"] = "news";
            
            ViewData["News"] = await _blogService.GetActiveBlogs(language, 0, 12);
        }
    }
}