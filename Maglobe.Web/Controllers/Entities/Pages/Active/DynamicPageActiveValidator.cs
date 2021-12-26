using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Active
{
    public class DynamicPageActiveValidator : AbstractValidator<DynamicPageActiveRequest>
    {
        public DynamicPageActiveValidator()
        {
            RuleFor(x => x.DynamicPageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
