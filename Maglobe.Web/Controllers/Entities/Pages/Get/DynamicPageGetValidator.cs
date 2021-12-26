using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Get
{
    public class DynamicPageGetValidator : AbstractValidator<DynamicPageGetRequest>
    {
        public DynamicPageGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
