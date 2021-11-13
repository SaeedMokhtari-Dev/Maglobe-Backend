using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Services;

namespace Maglobe.Web.Controllers.Entities.Certificates.Add
{
    public class CertificateAddHandler : ApiRequestHandler<CertificateAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        
        public CertificateAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CertificateAddRequest request)
        {
            Certificate certificate = await AddCertificate(request);
            
            return ActionResult.Ok(ApiMessages.CertificateMessage.AddedSuccessfully);
        }
        
        private async Task<Certificate> AddCertificate(CertificateAddRequest request)
        {
            Certificate certificate = await _context.ExecuteTransactionAsync(async () =>
            {
                Certificate newCertificate = _mapper.Map<Certificate>(request);
                
                if (!string.IsNullOrEmpty(request.Attachment))
                {
                    newCertificate.Attachment = new Attachment()
                    {
                        CreatedAt = DateTime.Now,
                        Image = request.Attachment.ToCharArray().Select(Convert.ToByte).ToArray()
                    };
                }

                newCertificate = (await _context.Certificates.AddAsync(newCertificate)).Entity;
                await _context.SaveChangesAsync();

                return newCertificate;
            });
            return certificate;
        }
    }
}