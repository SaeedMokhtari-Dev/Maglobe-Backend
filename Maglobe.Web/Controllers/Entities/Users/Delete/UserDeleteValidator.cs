using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Users.Delete
{
    public class UserDeleteValidator : AbstractValidator<UserDeleteRequest>
    {
        public UserDeleteValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
