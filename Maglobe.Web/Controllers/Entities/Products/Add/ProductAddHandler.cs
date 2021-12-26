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

namespace Maglobe.Web.Controllers.Entities.Products.Add
{
    public class ProductAddHandler : ApiRequestHandler<ProductAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        
        public ProductAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductAddRequest request)
        {
            Product product = await AddProduct(request);
            
            return ActionResult.Ok(ApiMessages.ProductMessage.AddedSuccessfully);
        }
        
        private async Task<Product> AddProduct(ProductAddRequest request)
        {
            Product product = await _context.ExecuteTransactionAsync(async () =>
            {
                Product newProduct = _mapper.Map<Product>(request);
                
                if (!string.IsNullOrEmpty(request.SmallPicture))
                {
                    Attachment attachment = new Attachment()
                    {
                        CreatedAt = DateTime.Now,
                        Image = request.SmallPicture.ToCharArray().Select(Convert.ToByte).ToArray()
                    };
                    var smallPicture = new ProductAttachment()
                    {
                        Attachment = attachment,
                        AttachmentType = AttachmentType.SmallPicture
                    };
                    newProduct.ProductAttachments.Add(smallPicture);
                }
                
                if (!string.IsNullOrEmpty(request.LargePicture))
                {
                    Attachment attachment = new Attachment()
                    {
                        CreatedAt = DateTime.Now,
                        Image = request.LargePicture.ToCharArray().Select(Convert.ToByte).ToArray()
                    };
                    var largePicture = new ProductAttachment()
                    {
                        Attachment = attachment,
                        AttachmentType = AttachmentType.LargePicture
                    };
                    newProduct.ProductAttachments.Add(largePicture);
                }

                foreach (var requestProductCertificateId in request.ProductCertificateIds)
                {
                    newProduct.ProductCertificates.Add(new ProductCertificate()
                    {
                        CertificateId = requestProductCertificateId
                    });
                }

                newProduct = (await _context.Products.AddAsync(newProduct)).Entity;
                await _context.SaveChangesAsync();

                return newProduct;
            });
            return product;
        }
    }
}