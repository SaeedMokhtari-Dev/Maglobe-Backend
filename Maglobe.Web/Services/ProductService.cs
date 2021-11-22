using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
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
                .Where(w => w.IsActive && w.Language == language.ToString())
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            return await query.Select(w => new ProductViewModel()
            {
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
                DisplayOrder = w.DisplayOrder
            }) .ToListAsync();
        }
    }
}