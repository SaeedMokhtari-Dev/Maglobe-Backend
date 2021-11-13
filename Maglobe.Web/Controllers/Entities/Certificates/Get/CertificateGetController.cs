using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.Get
{
    [Route(Endpoints.ApiCertificateGet)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateGetController : ApiController<CertificateGetRequest>
    {
        public CertificateGetController(IApiRequestHandler<CertificateGetRequest> handler, IValidator<CertificateGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
