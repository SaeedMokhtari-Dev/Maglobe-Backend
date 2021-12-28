using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Detail
{
    public class TestimonialDetailHandler : ApiRequestHandler<TestimonialDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public TestimonialDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(TestimonialDetailRequest request)
        {
            Testimonial testimonial = await _context.Testimonials
                .Include(w => w.Attachment)
                .Include(w => w.SmallPicture)
                .FirstOrDefaultAsync(w => w.Id == request.TestimonialId);

            if (testimonial == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            TestimonialDetailResponse response = _mapper.Map<TestimonialDetailResponse>(testimonial);
            
            return ActionResult.Ok(response);
        }
    }
}
