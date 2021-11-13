using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Products.Detail
{
    public class ProductDetailValidator : AbstractValidator<ProductDetailRequest>
    {
        public ProductDetailValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
