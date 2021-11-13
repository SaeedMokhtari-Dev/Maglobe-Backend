using FluentValidation;

namespace Maglobe.Web.Controllers.Entities.Products.List
{
    public class ProductListValidator : AbstractValidator<ProductListRequest>
    {
        public ProductListValidator()
        {
        }
    }
}
