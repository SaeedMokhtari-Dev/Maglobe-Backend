using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Products : BasePageModel
    {
        private readonly ProductService _productService;
        public Products(ProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            
            ViewData["Products"] = await _productService.GetActiveProducts(language);
            ViewData["BodyClass"] = "products";

        }
    }
}