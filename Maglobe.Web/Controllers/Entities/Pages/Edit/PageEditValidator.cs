using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Edit
{
    public class PageEditValidator : AbstractValidator<PageEditRequest>
    {
        public PageEditValidator()
        {
            RuleFor(x => x.PageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
