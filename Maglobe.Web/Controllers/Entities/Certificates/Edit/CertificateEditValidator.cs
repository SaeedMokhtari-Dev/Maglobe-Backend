using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Certificates.Edit
{
    public class CertificateEditValidator : AbstractValidator<CertificateEditRequest>
    {
        public CertificateEditValidator()
        {
            RuleFor(x => x.CertificateId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
