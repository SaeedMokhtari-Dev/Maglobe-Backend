using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Active
{
    public class PageActiveValidator : AbstractValidator<PageActiveRequest>
    {
        public PageActiveValidator()
        {
            RuleFor(x => x.PageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
