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
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Products.Edit
{
    public class ProductEditHandler : ApiRequestHandler<ProductEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public ProductEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductEditRequest request)
        {
            Product editProduct = await _context.Products
                .Include(w => w.ProductAttachments)
                .Include(w => w.ProductCertificates)
                .FirstOrDefaultAsync(w => w.Id == request.ProductId);

            if (editProduct == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditProduct(editProduct, request);
            return ActionResult.Ok(ApiMessages.ProductMessage.EditedSuccessfully);
        }

        private async Task EditProduct(Product editProduct, ProductEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editProduct);
                
                if (request.SmallPictureChanged && !string.IsNullOrEmpty(request.SmallPicture))
                {
                    var smallPicture = editProduct.ProductAttachments.FirstOrDefault(w => w.AttachmentType == AttachmentType.SmallPicture);
                    if (smallPicture != null)
                    {
                        var attachment = await _context.Attachments.FirstAsync(w => w.Id == smallPicture.AttachmentId);
                        attachment.Image = request.SmallPicture.ToCharArray().Select(Convert.ToByte).ToArray();
                    }
                    else
                    {
                        Attachment attachment = new Attachment()
                        {
                            CreatedAt = DateTime.Now,
                            Image = request.SmallPicture.ToCharArray().Select(Convert.ToByte).ToArray()
                        };
                        var smallAttachment = new ProductAttachment()
                        {
                            Attachment = attachment,
                            AttachmentType = AttachmentType.SmallPicture
                        };
                        editProduct.ProductAttachments.Add(smallAttachment);
                    }
                }
                
                if (request.LargePictureChanged && !string.IsNullOrEmpty(request.LargePicture))
                {
                    var largePicture = editProduct.ProductAttachments.FirstOrDefault(w => w.AttachmentType == AttachmentType.LargePicture);
                    if (largePicture != null)
                    {
                        var attachment = await _context.Attachments.FirstAsync(w => w.Id == largePicture.AttachmentId);
                        attachment.Image = request.LargePicture.ToCharArray().Select(Convert.ToByte).ToArray();
                    }
                    else
                    {
                        Attachment attachment = new Attachment()
                        {
                            CreatedAt = DateTime.Now,
                            Image = request.LargePicture.ToCharArray().Select(Convert.ToByte).ToArray()
                        };
                        var largeAttachment = new ProductAttachment()
                        {
                            Attachment = attachment,
                            AttachmentType = AttachmentType.LargePicture
                        };
                        editProduct.ProductAttachments.Add(largeAttachment);
                    }
                }
                
                var certificateIds = editProduct.ProductCertificates
                    .Select(w => w.CertificateId).ToList();
                
                var shouldRemoveCertificateIds = certificateIds.Except(request.ProductCertificateIds).ToList();
                foreach (var shouldRemoveCertificateId in shouldRemoveCertificateIds)
                {
                    var removeEntity = editProduct.ProductCertificates
                        .Single(w => w.CertificateId == shouldRemoveCertificateId);
                    _context.Remove(removeEntity);
                }
                
                var shouldAdded = request.ProductCertificateIds.Except(certificateIds).ToList();
                foreach (var w in shouldAdded)
                {
                    editProduct.ProductCertificates.Add(new ProductCertificate()
                    {
                        CertificateId = w,
                        ProductId = editProduct.Id
                    });
                }
                
                await _context.SaveChangesAsync();

                return editProduct;
            });
        }
    }
}