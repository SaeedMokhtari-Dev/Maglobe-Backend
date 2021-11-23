using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Detail
{
    public class DynamicPageDetailValidator : AbstractValidator<DynamicPageDetailRequest>
    {
        public DynamicPageDetailValidator()
        {
            RuleFor(x => x.DynamicPageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
