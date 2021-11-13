using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Get
{
    public class TestimonialGetHandler : ApiRequestHandler<TestimonialGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public TestimonialGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(TestimonialGetRequest request)
        {
            var query = _context.Testimonials.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<TestimonialGetResponseItem>>(result);

            TestimonialGetResponse response = new TestimonialGetResponse();
            response.TotalCount = await _context.Testimonials.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
