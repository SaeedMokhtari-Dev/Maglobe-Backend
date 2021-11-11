using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Attachments.Detail
{
    public class AttachmentDetailValidator : AbstractValidator<AttachmentDetailRequest>
    {
        public AttachmentDetailValidator()
        {
            RuleFor(x => x.AttachmentId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
