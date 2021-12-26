using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Delete
{
    public class DynamicPageDeleteValidator : AbstractValidator<DynamicPageDeleteRequest>
    {
        public DynamicPageDeleteValidator()
        {
            RuleFor(x => x.DynamicPageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
