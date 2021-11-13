using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Certificates.Active
{
    public class CertificateActiveHandler : ApiRequestHandler<CertificateActiveRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CertificateActiveHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CertificateActiveRequest request)
        {
            Certificate certificate = await _context.Certificates
                .FindAsync(request.CertificateId);

            if (certificate == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            certificate.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.CertificateMessage.ActivatedSuccessfully);
        }
    }
}
