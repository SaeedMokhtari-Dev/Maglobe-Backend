using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Users.Detail
{
    public class UserDetailValidator : AbstractValidator<UserDetailRequest>
    {
        public UserDetailValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
