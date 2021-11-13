using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Services;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Add
{
    public class TestimonialAddHandler : ApiRequestHandler<TestimonialAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        
        public TestimonialAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(TestimonialAddRequest request)
        {
            Testimonial testimonial = await AddTestimonial(request);
            
            return ActionResult.Ok(ApiMessages.TestimonialMessage.AddedSuccessfully);
        }
        
        private async Task<Testimonial> AddTestimonial(TestimonialAddRequest request)
        {
            Testimonial testimonial = await _context.ExecuteTransactionAsync(async () =>
            {
                Testimonial newTestimonial = _mapper.Map<Testimonial>(request);
                
                if (!string.IsNullOrEmpty(request.Attachment))
                {
                    newTestimonial.Attachment = new Attachment()
                    {
                        CreatedAt = DateTime.Now,
                        Image = request.Attachment.ToCharArray().Select(Convert.ToByte).ToArray()
                    };
                }

                newTestimonial = (await _context.Testimonials.AddAsync(newTestimonial)).Entity;
                await _context.SaveChangesAsync();

                return newTestimonial;
            });
            return testimonial;
        }
    }
}