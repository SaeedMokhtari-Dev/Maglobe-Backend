using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Delete
{
    public class TestimonialDeleteHandler : ApiRequestHandler<TestimonialDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public TestimonialDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(TestimonialDeleteRequest request)
        {
            Testimonial testimonial = await _context.Testimonials
                .FindAsync(request.TestimonialId);

            if (testimonial == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.Testimonials.Remove(testimonial);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.TestimonialMessage.DeletedSuccessfully);
        }
    }
}
