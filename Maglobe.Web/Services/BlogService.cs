using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Extensions;
using Maglobe.Web.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Services
{
    public class BlogService: ITransient
    {
        private readonly MaglobeContext _context;

        public BlogService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<List<BlogListViewModel>> GetActiveBlogs(Language language, int pageIndex, int pageSize)
        {
            var query = _context.Blogs
                .Where(w => w.IsActive && w.Language == language.ToString())
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            query = query.Skip(pageSize * pageIndex).Take(pageSize).AsQueryable();

            var result = await query.Select(w => new BlogListViewModel()
            {
                Title = w.Title,
                Picture = w.AttachmentId.HasValue
                    ? String.Join("", w.Attachment.Image.Select(Convert.ToChar))
                    : string.Empty
            }).ToListAsync();

            return result;

        }

        public async Task<BlogDetailViewModel> GetBlogDetail(Language language, long id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(w => w.Language == language.ToString() &&
                                                                     w.Id == id);

            return new BlogDetailViewModel()
            {
                Title = blog.Title,
                Date = blog.PublishedDate.ToPersianDateAndDayName(),
                Description = blog.Description,
                Picture =  blog.AttachmentId.HasValue ? String.Join("", blog.Attachment.Image.Select(Convert.ToChar)) : string.Empty
            };
        }
    }
}