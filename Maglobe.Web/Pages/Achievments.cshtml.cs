using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Achievments : BasePageModel
    {
        public Achievments()
        {
        }
        public void OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            ViewData["BodyClass"] = "achievments";
        }
    }
}