using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Detail
{
    public class PageDetailValidator : AbstractValidator<PageDetailRequest>
    {
        public PageDetailValidator()
        {
            RuleFor(x => x.PageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
