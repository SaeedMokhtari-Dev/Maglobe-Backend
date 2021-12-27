using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Blogs.Detail
{
    public class BlogDetailHandler : ApiRequestHandler<BlogDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public BlogDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BlogDetailRequest request)
        {
            Blog blog = await _context.Blogs
                .Include(w => w.Attachment)
                .FirstOrDefaultAsync(w => w.Id == request.BlogId);

            if (blog == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            BlogDetailResponse response = _mapper.Map<BlogDetailResponse>(blog);
            
            return ActionResult.Ok(response);
        }
    }
}
