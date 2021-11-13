using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Certificates.Active
{
    public class CertificateActiveValidator : AbstractValidator<CertificateActiveRequest>
    {
        public CertificateActiveValidator()
        {
            RuleFor(x => x.CertificateId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
