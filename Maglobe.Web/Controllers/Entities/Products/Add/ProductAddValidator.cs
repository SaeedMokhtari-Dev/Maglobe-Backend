using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Products.Add
{
    public class ProductAddValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddValidator()
        {
        }
    }
}
