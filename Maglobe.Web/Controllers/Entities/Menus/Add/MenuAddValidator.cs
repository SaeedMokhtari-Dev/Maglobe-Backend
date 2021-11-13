using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Menus.Add
{
    public class MenuAddValidator : AbstractValidator<MenuAddRequest>
    {
        public MenuAddValidator()
        {
        }
    }
}
