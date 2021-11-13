using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.Delete
{
    [Route(Endpoints.ApiCertificateDelete)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateDeleteController : ApiController<CertificateDeleteRequest>
    {
        public CertificateDeleteController(IApiRequestHandler<CertificateDeleteRequest> handler, IValidator<CertificateDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
