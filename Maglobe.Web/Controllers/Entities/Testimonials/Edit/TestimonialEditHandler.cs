using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Edit
{
    public class TestimonialEditHandler : ApiRequestHandler<TestimonialEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public TestimonialEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(TestimonialEditRequest request)
        {
            Testimonial editTestimonial = await _context.Testimonials
                .Include(w => w.Attachment)
                .FirstOrDefaultAsync(w => w.Id == request.TestimonialId);

            if (editTestimonial == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditTestimonial(editTestimonial, request);
            return ActionResult.Ok(ApiMessages.TestimonialMessage.EditedSuccessfully);
        }

        private async Task EditTestimonial(Testimonial editTestimonial, TestimonialEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editTestimonial);
                
                if (request.PictureChanged && !string.IsNullOrEmpty(request.Picture))
                {
                    if (editTestimonial.AttachmentId.HasValue)
                    {
                        editTestimonial.Attachment.CreatedAt = DateTime.Now;
                        editTestimonial.Attachment.Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray();
                    }
                    else
                    {
                        editTestimonial.Attachment = new Attachment
                        {
                            CreatedAt = DateTime.Now,
                            Image = request.Picture.ToCharArray().Select(Convert.ToByte).ToArray()
                        };
                    }
                }
                
                if (request.SmallPictureChanged && !string.IsNullOrEmpty(request.SmallPicture))
                {
                    if (editTestimonial.SmallPictureId.HasValue)
                    {
                        editTestimonial.SmallPicture.CreatedAt = DateTime.Now;
                        editTestimonial.SmallPicture.Image = request.SmallPicture.ToCharArray().Select(Convert.ToByte).ToArray();
                    }
                    else
                    {
                        editTestimonial.SmallPicture = new Attachment
                        {
                            CreatedAt = DateTime.Now,
                            Image = request.SmallPicture.ToCharArray().Select(Convert.ToByte).ToArray()
                        };
                    }
                }
                
                await _context.SaveChangesAsync();

                return editTestimonial;
            });
        }
    }
}