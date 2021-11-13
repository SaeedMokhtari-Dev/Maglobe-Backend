using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Certificates.Delete
{
    public class CertificateDeleteHandler : ApiRequestHandler<CertificateDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CertificateDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CertificateDeleteRequest request)
        {
            Certificate certificate = await _context.Certificates
                .FindAsync(request.CertificateId);

            if (certificate == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.Certificates.Remove(certificate);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.CertificateMessage.DeletedSuccessfully);
        }
    }
}
