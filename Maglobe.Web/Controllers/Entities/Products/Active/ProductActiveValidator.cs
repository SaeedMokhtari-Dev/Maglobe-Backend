using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Products.Active
{
    public class ProductActiveValidator : AbstractValidator<ProductActiveRequest>
    {
        public ProductActiveValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
