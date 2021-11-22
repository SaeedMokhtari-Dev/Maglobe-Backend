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
    public class TestimonialService: ITransient
    {
        private readonly MaglobeContext _context;

        public TestimonialService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<List<TestimonialViewModel>> GetActiveTestimonials(Language language)
        {
            var query = _context.Testimonials
                .Include(w => w.Attachment)
                .Where(w => w.IsActive && w.Language == language.ToString())
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            return await query.Select(w => new TestimonialViewModel()
            {
                Comment = w.Comment,
                DisplayOrder = w.DisplayOrder,
                Picture = String.Join("", w.Attachment.Image.Select(Convert.ToChar))
            }) .ToListAsync();
        }
    }
}