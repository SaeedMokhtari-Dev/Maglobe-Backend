using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.Detail
{
    [Route(Endpoints.ApiCertificateDetail)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateDetailController : ApiController<CertificateDetailRequest>
    {
        public CertificateDetailController(IApiRequestHandler<CertificateDetailRequest> handler, IValidator<CertificateDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
