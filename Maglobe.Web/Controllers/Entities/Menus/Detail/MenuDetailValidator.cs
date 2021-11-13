using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Menus.Detail
{
    public class MenuDetailValidator : AbstractValidator<MenuDetailRequest>
    {
        public MenuDetailValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
