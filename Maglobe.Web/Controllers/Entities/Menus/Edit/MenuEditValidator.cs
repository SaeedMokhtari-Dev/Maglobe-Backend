using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Menus.Edit
{
    public class MenuEditValidator : AbstractValidator<MenuEditRequest>
    {
        public MenuEditValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
