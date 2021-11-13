using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.Active
{
    [Route(Endpoints.ApiCertificateActive)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateActiveController : ApiController<CertificateActiveRequest>
    {
        public CertificateActiveController(IApiRequestHandler<CertificateActiveRequest> handler, IValidator<CertificateActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
