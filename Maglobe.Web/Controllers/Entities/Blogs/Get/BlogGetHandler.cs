using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Blogs.Get
{
    public class BlogGetHandler : ApiRequestHandler<BlogGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public BlogGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BlogGetRequest request)
        {
            var query = _context.Blogs.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<BlogGetResponseItem>>(result);

            BlogGetResponse response = new BlogGetResponse();
            response.TotalCount = await _context.Blogs.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
