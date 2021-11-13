using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Menus.Delete
{
    public class MenuDeleteValidator : AbstractValidator<MenuDeleteRequest>
    {
        public MenuDeleteValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
