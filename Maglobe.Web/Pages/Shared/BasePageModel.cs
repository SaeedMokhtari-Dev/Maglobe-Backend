using System;
using Maglobe.Core.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages.Shared
{
    public class BasePageModel: PageModel
    {
        public Language CheckAndSetSiteLanguage(string siteLanguage)
        {
            ViewData["siteLanguage"] = siteLanguage;
            Enum.TryParse(siteLanguage, out Language language);
            return language;
        }
    }
}