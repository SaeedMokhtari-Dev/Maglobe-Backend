using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Edit
{
    public class DynamicPageEditValidator : AbstractValidator<DynamicPageEditRequest>
    {
        public DynamicPageEditValidator()
        {
            RuleFor(x => x.DynamicPageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
