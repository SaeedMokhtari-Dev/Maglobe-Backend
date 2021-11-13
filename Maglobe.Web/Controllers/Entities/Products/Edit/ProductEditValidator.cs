using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Products.Edit
{
    public class ProductEditValidator : AbstractValidator<ProductEditRequest>
    {
        public ProductEditValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
