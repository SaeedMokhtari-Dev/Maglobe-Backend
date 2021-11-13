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
using Maglobe.Web.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Products.Detail
{
    public class ProductDetailHandler : ApiRequestHandler<ProductDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public ProductDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductDetailRequest request)
        {
            Product product = await _context.Products
                .Include(w => w.ProductAttachments).ThenInclude(w => w.Attachment)
                .Include(w => w.ProductCertificates).ThenInclude(w => w.Certificate)
                .FirstOrDefaultAsync(w => w.Id == request.ProductId);

            if (product == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            ProductDetailResponse response = _mapper.Map<ProductDetailResponse>(product);
            var smallPicture = product.ProductAttachments.FirstOrDefault(w => w.AttachmentType == AttachmentType.SmallPicture);
            if (smallPicture != null)
            {
                response.SmallPicture = String.Join("", smallPicture.Attachment.Image.Select(Convert.ToChar));
            }
            var largePicture = product.ProductAttachments.FirstOrDefault(w => w.AttachmentType == AttachmentType.LargePicture);
            if (largePicture != null)
            {
                response.LargePicture = String.Join("", largePicture.Attachment.Image.Select(Convert.ToChar));
            }
            
            
            return ActionResult.Ok(response);
        }
    }
}
