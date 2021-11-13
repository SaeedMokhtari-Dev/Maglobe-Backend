using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Menus.Active
{
    public class MenuActiveValidator : AbstractValidator<MenuActiveRequest>
    {
        public MenuActiveValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
