using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Blogs.Active
{
    public class BlogActiveHandler : ApiRequestHandler<BlogActiveRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public BlogActiveHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BlogActiveRequest request)
        {
            Blog blog = await _context.Blogs
                .FindAsync(request.BlogId);

            if (blog == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            blog.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.BlogMessage.ActivatedSuccessfully);
        }
    }
}
