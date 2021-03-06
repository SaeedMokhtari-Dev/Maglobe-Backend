using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Active
{
    public class TestimonialActiveHandler : ApiRequestHandler<TestimonialActiveRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public TestimonialActiveHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(TestimonialActiveRequest request)
        {
            Testimonial testimonial = await _context.Testimonials
                .FindAsync(request.TestimonialId);

            if (testimonial == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            testimonial.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.TestimonialMessage.ActivatedSuccessfully);
        }
    }
}
