using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Auth.ResetPassword
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.Auth.EmailRequired);
        }
    }
}
