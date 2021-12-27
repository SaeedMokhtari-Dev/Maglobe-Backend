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

namespace Maglobe.Web.Controllers.Entities.Blogs.Edit
{
    public class BlogEditHandler : ApiRequestHandler<BlogEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public BlogEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BlogEditRequest request)
        {
            Blog editBlog = await _context.Blogs
                .Include(w => w.Attachment)
                .FirstOrDefaultAsync(w => w.Id == request.BlogId);

            if (editBlog == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditBlog(editBlog, request);
            return ActionResult.Ok(ApiMessages.BlogMessage.EditedSuccessfully);
        }

        private async Task EditBlog(Blog editBlog, BlogEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editBlog);
                
                if (request.PictureChanged && !string.IsNullOrEmpty(request.Picture))
                {
                    if (editBlog.AttachmentId.HasValue)
                    {
                        editBlog.Attachment.CreatedAt = DateTime.Now;
                        editBlog.Attachment.Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray();
                    }
                    else
                    {
                        editBlog.Attachment = new Attachment
                        {
                            CreatedAt = DateTime.Now,
                            Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray()
                        };
                    }
                }
                
                await _context.SaveChangesAsync();

                return editBlog;
            });
        }
    }
}