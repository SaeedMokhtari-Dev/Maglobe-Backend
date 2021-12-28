using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class ProductDetails : BasePageModel
    {
        private readonly ProductService _productService;
        public ProductDetails(ProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet(long productId, string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            
            ViewData["ProductDetail"] = await _productService.GetProductDetail(language, productId);
            ViewData["BodyClass"] = "products";

        }
    }
}