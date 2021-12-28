using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Controllers.Entities.Products.Detail;
using Maglobe.Web.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Services
{
    public class ProductService: ITransient
    {
        private readonly MaglobeContext _context;

        public ProductService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetActiveProducts(Language language)
        {
            var query = _context.Products
                .Include(w => w.ProductAttachments).ThenInclude(w => w.Attachment)
                .Include(w => w.ProductCertificates).ThenInclude(w => w.Certificate)
                .ThenInclude(w => w.Attachment)
                .Where(w => w.IsActive && w.Language == language.ToString())
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();
            var products = await query.Select(w => new Product()
            {
                Id = w.Id, Name = w.Name, Description = w.Description, Model = w.Model, Quality = w.Quality,
                Volume = w.Volume, DescriptionSeo = w.DescriptionSeo, ProductAttachments = w.ProductAttachments,
                DisplayOrder = w.DisplayOrder, OilType = w.OilType, ProductCertificates = w.ProductCertificates
            }).ToListAsync();
            var result = products.Select(w => new ProductViewModel()
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Model = w.Model,
                Quality = w.Quality,
                Volume = w.Volume,
                DescriptionSeo = w.DescriptionSeo,
                LargePicture =  w.ProductAttachments.Any(e => e.AttachmentType == AttachmentType.LargePicture) ?
                    String.Join("", w.ProductAttachments.First(e => e.AttachmentType == AttachmentType.LargePicture).Attachment.Image.Select(Convert.ToChar)) : string.Empty,
                SmallPicture =  w.ProductAttachments.Any(e => e.AttachmentType == AttachmentType.SmallPicture) ?
                    String.Join("", w.ProductAttachments.First(e => e.AttachmentType == AttachmentType.SmallPicture).Attachment.Image.Select(Convert.ToChar)) : string.Empty,
                CertificateItems = w.ProductCertificates.Select(e => new CertificateItem()
                {
                  Key = e.Id,
                  Title = e.Certificate.Title,
                  Image = String.Join("", e.Certificate?.Attachment?.Image.Select(Convert.ToChar))
                }).ToList(),
                DisplayOrder = w.DisplayOrder,
                OilType = w.OilType
            }).ToList();

            return result;
        }

        public async Task<ProductDetailViewModel> GetProductDetail(Language language, long productId)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(w => w.Id == productId && w.IsActive && w.Language == language.ToString());

            return new ProductDetailViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Model = product.Model,
                Quality = product.Quality,
                Volume = product.Volume,
                DescriptionSeo = product.DescriptionSeo,
                DisplayOrder = product.DisplayOrder,
                DetailDescription = product.DetailDescription,
                OilType = product.OilType
            };
        }
    }
}