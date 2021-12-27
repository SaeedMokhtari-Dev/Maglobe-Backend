using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Blogs.List
{
    public class BlogListHandler : ApiRequestHandler<BlogListRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public BlogListHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BlogListRequest request)
        {
            var query = _context.Blogs
                .OrderByDescending(w => w.Id)
                .AsQueryable();

            var response = await query.Select(w =>
            new BlogListResponseItem() {
                Key = w.Id, 
                Title = w.Title,
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
