using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Products.Delete
{
    public class ProductDeleteValidator : AbstractValidator<ProductDeleteRequest>
    {
        public ProductDeleteValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
