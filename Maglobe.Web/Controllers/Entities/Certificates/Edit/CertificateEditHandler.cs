using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Certificates.Edit
{
    public class CertificateEditHandler : ApiRequestHandler<CertificateEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CertificateEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CertificateEditRequest request)
        {
            Certificate editCertificate = await _context.Certificates
                .Include(w => w.Attachment)
                .FirstOrDefaultAsync(w => w.Id == request.CertificateId);

            if (editCertificate == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditCertificate(editCertificate, request);
            return ActionResult.Ok(ApiMessages.CertificateMessage.EditedSuccessfully);
        }

        private async Task EditCertificate(Certificate editCertificate, CertificateEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editCertificate);
                
                if (request.PictureChanged && !string.IsNullOrEmpty(request.Picture))
                {
                    if (editCertificate.AttachmentId.HasValue)
                    {
                        editCertificate.Attachment.CreatedAt = DateTime.Now;
                        editCertificate.Attachment.Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray();
                    }
                    else
                    {
                        editCertificate.Attachment = new Attachment
                        {
                            CreatedAt = DateTime.Now,
                            Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray()
                        };
                    }
                }
                
                await _context.SaveChangesAsync();

                return editCertificate;
            });
        }
    }
}