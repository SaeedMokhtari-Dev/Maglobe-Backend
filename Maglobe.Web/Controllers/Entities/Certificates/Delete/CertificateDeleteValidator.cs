using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Certificates.Delete
{
    public class CertificateDeleteValidator : AbstractValidator<CertificateDeleteRequest>
    {
        public CertificateDeleteValidator()
        {
            RuleFor(x => x.CertificateId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
