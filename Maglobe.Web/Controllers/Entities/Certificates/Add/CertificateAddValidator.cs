using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Certificates.Add
{
    public class CertificateAddValidator : AbstractValidator<CertificateAddRequest>
    {
        public CertificateAddValidator()
        {
        }
    }
}
