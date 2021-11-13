using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Settings.Delete
{
    public class SettingDeleteValidator : AbstractValidator<SettingDeleteRequest>
    {
        public SettingDeleteValidator()
        {
            RuleFor(x => x.SettingId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
