using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Certificates.Detail
{
    public class CertificateDetailValidator : AbstractValidator<CertificateDetailRequest>
    {
        public CertificateDetailValidator()
        {
            RuleFor(x => x.CertificateId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
