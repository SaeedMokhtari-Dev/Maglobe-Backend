using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Auth.ValidateResetPasswordToken
{
    public class ValidateResetPasswordTokenValidator : AbstractValidator<ValidateResetPasswordTokenRequest>
    {
        public ValidateResetPasswordTokenValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage(ApiMessages.Auth.TokenRequired);
        }
    }
}
