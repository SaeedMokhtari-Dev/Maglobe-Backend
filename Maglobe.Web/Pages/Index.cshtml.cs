using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Index : BasePageModel
    {
        public Index()
        {
        }
        public void OnGet(string siteLanguage)
        {
            CheckAndSetSiteLanguage(siteLanguage);
            ViewData["BodyClass"] = "home";
        }
    }
}