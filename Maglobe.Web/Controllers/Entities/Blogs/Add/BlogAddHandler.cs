using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Blogs.Add
{
    public class BlogAddHandler : ApiRequestHandler<BlogAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        
        public BlogAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BlogAddRequest request)
        {
            Blog blog = await AddBlog(request);
            
            return ActionResult.Ok(ApiMessages.BlogMessage.AddedSuccessfully);
        }
        
        private async Task<Blog> AddBlog(BlogAddRequest request)
        {
            Blog blog = await _context.ExecuteTransactionAsync(async () =>
            {
                Blog newBlog = _mapper.Map<Blog>(request);
                
                if (!string.IsNullOrEmpty(request.Picture))
                {
                    newBlog.Attachment = new Attachment()
                    {
                        CreatedAt = DateTime.Now,
                        Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray()
                    };
                }

                newBlog = (await _context.Blogs.AddAsync(newBlog)).Entity;
                await _context.SaveChangesAsync();

                return newBlog;
            });
            return blog;
        }
    }
}