using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Delete
{
    public class PageDeleteValidator : AbstractValidator<PageDeleteRequest>
    {
        public PageDeleteValidator()
        {
            RuleFor(x => x.PageId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
