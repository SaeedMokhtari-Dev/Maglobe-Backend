using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Settings.Detail
{
    public class SettingDetailValidator : AbstractValidator<SettingDetailRequest>
    {
        public SettingDetailValidator()
        {
            RuleFor(x => x.SettingId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
