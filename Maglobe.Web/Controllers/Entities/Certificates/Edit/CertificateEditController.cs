using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.Edit
{
    [Route(Endpoints.ApiCertificateEdit)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateEditController : ApiController<CertificateEditRequest>
    {
        public CertificateEditController(IApiRequestHandler<CertificateEditRequest> handler, IValidator<CertificateEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
