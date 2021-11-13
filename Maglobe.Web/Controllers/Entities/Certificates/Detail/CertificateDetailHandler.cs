using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Certificates.Detail
{
    public class CertificateDetailHandler : ApiRequestHandler<CertificateDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CertificateDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CertificateDetailRequest request)
        {
            Certificate certificate = await _context.Certificates
                .FirstOrDefaultAsync(w => w.Id == request.CertificateId);

            if (certificate == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            CertificateDetailResponse response = _mapper.Map<CertificateDetailResponse>(certificate);
            
            return ActionResult.Ok(response);
        }
    }
}
