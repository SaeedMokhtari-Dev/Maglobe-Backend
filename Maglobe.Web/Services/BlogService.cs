using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
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
                .Include(w => w.Attachment)
                .Where(w => w.IsActive && w.Language == language.ToString())
                .OrderBy(w => w.DisplayOrder)
                .AsQueryable();

            query = query.Skip(pageSize * pageIndex).Take(pageSize).AsQueryable();

            var news = await query.Select(w => new Blog()
            {
                Id = w.Id,
                Title = w.Title,
                Attachment = w.Attachment,
                AttachmentId = w.AttachmentId
            }).ToListAsync();
            var result = news.Select(w => new BlogListViewModel()
            {
                Id = w.Id,
                Title = w.Title,
                Picture = w.AttachmentId.HasValue
                    ? String.Join("", w.Attachment.Image.Select(Convert.ToChar))
                    : string.Empty
            }).ToList();

            return result;

        }

        public async Task<BlogDetailViewModel> GetBlogDetail(Language language, long id)
        {
            var blog = await _context.Blogs.Include(w => w.Attachment).FirstOrDefaultAsync(w => w.Language == language.ToString() &&
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