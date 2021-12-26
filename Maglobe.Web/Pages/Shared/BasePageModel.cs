using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Http;
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