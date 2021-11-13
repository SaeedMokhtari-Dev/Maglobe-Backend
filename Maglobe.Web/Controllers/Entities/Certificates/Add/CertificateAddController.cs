using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.Add
{
    [Route(Endpoints.ApiCertificateAdd)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateAddController : ApiController<CertificateAddRequest>
    {
        public CertificateAddController(IApiRequestHandler<CertificateAddRequest> handler, IValidator<CertificateAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
