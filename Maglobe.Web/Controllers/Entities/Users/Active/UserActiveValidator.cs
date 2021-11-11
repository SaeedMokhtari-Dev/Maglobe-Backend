using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Users.Active
{
    public class UserActiveValidator : AbstractValidator<UserActiveRequest>
    {
        public UserActiveValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
