using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Benefits : BasePageModel
    {
        public Benefits()
        {
        }

        public void OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            ViewData["BodyClass"] = "benefits";
        }
    }
}