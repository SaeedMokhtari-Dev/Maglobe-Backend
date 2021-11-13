using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Settings.Edit
{
    public class SettingEditValidator : AbstractValidator<SettingEditRequest>
    {
        public SettingEditValidator()
        {
            RuleFor(x => x.SettingId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
