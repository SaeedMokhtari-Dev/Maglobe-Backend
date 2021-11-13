using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Certificates.List
{
    [Route(Endpoints.ApiCertificateList)]
    [ApiExplorerSettings(GroupName = "Certificate")]
    [Authorize]
    public class CertificateListController : ApiController<CertificateListRequest>
    {
        public CertificateListController(IApiRequestHandler<CertificateListRequest> handler, IValidator<CertificateListRequest> validator) : base(handler, validator)
        {
        }
    }
}
