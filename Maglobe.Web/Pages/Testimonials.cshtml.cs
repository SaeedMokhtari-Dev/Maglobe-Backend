using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Testimonials : BasePageModel
    {
        private readonly TestimonialService _testimonialService;
        public Testimonials(TestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public async Task OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            
            ViewData["Testimonials"] = await _testimonialService.GetActiveTestimonials(language);
            ViewData["BodyClass"] = "testimonials";

        }
    }
}