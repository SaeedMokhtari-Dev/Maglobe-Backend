using FluentValidation;

namespace Maglobe.Web.Controllers.Entities.Products.Add
{
    public class ProductAddValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddValidator()
        {
        }
    }
}
