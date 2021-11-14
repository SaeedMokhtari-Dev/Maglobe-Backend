using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Index : PageModel
    {
        public void OnGet()
        {
            var ww = "ReferenceEquals();";
        }
    }
}